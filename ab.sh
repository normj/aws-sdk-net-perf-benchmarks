#!/usr/bin/env bash
# A/B BenchmarkDotNet comparison of AWSSDK.Core between two aws-sdk-net commits.
#
# Usage:
#   ab.sh <base-ref> <pr-ref> <bdn-filter> [options]
#
# <base-ref> and <pr-ref> are refs or SHAs in the aws-sdk-net checkout, for example
# origin/main and perf/core-signing-foo. The benchmark source is this repo's
# CoreBenchmarks/ as it is in the working tree when the run starts.
#
# Options:
#   --sdk-repo <path>     aws-sdk-net checkout (default: $AWS_SDK_NET_REPO, else ../aws-sdk-net next to this repo)
#   --runtimes "<tfms>"   Target frameworks to measure, each run as the BDN host (default: "net10.0 net11.0")
#   --rounds <n>          Interleaved rounds, base then PR each round (default: 3)
#   --job <name>          BDN job: Default, Short, Medium, Long, Dry (default: Default)
#   --out <dir>           Output directory (default: ./ab-results/<base>-<pr>-<timestamp>)
#   --background          Detach from the calling shell (setsid nohup), log to <out>/ab.log, print the PID
#   --keep-worktrees      Keep this run's worktrees instead of removing them at exit
#
# Environment:
#   AB_LOCK        Benchmark lock file (default: /tmp/core-bench.lock)
#   AB_WORKTREES   Parent directory for per-run worktrees (default: ~/code/perf-ab-worktrees)
#   AB_MAX_LOAD    Before each measurement, wait until the number of other runnable tasks (sampled
#                  over 5 seconds) is at or below this (default: nproc / 8, minimum 2)
#   AB_LOAD_WAIT   Maximum seconds to wait for the machine to go quiet before measuring anyway (default: 1800)
#   AWS_SDK_NET_REPO  Default for --sdk-repo
#
# Both sides build the same snapshot of CoreBenchmarks/, so only AWSSDK.Core
# differs. Benchmarks must therefore only call APIs that exist on <base-ref>.
#
# Each run gets its own pair of aws-sdk-net worktrees and its own copies of the
# benchmark project, so concurrent runs never touch each other's files. Only one
# run measures at a time (flock on $AB_LOCK); setup and builds happen outside it.
#
# Writes <out>/summary.md (paste into the PR description), <out>/meta.json and
# <out>/bench-src/ (the benchmark source used). record.sh commits them to a
# pr/<n>-<name> branch of this repo.

set -euo pipefail

# Everything runs inside main, which bash parses in full before executing. Editing
# or checking out a different version of this file mid-run cannot change a run in
# progress.
main() {
  local SCRIPT_PATH SCRIPT_DIR
  SCRIPT_PATH=$(realpath "${BASH_SOURCE[0]}")
  SCRIPT_DIR=$(dirname "$SCRIPT_PATH")

  usage() { sed -n '2,40p' "$SCRIPT_PATH" | sed 's/^# \{0,1\}//'; exit 2; }

  [[ $# -ge 3 ]] || usage
  local BASE_REF=$1 PR_REF=$2 FILTER=$3; shift 3

  local RUNTIMES="net10.0 net11.0" ROUNDS=3 JOB=Default OUT="" BACKGROUND=0
  local SDK_REPO=${AWS_SDK_NET_REPO:-$SCRIPT_DIR/../aws-sdk-net}
  KEEP=0  # global: read by the EXIT trap, which runs after main returns
  while [[ $# -gt 0 ]]; do
    case "$1" in
      --runtimes) RUNTIMES=$2; shift 2 ;;
      --rounds)   ROUNDS=$2; shift 2 ;;
      --job)      JOB=$2; shift 2 ;;
      --out)      OUT=$2; shift 2 ;;
      --sdk-repo) SDK_REPO=$2; shift 2 ;;
      --background) BACKGROUND=1; shift ;;
      --keep-worktrees) KEEP=1; shift ;;
      -h|--help)  usage ;;
      *) echo "Unknown option: $1" >&2; usage ;;
    esac
  done

  # Resolve symlinks (for example a symlinked home directory): mixed paths break MSBuild project references.
  # REPO is global: the EXIT trap reads it.
  local WT_ROOT LOCK
  [[ -d "$SDK_REPO" ]] || { echo "aws-sdk-net checkout not found at $SDK_REPO (use --sdk-repo or AWS_SDK_NET_REPO)" >&2; exit 2; }
  REPO=$(git -C "$SDK_REPO" rev-parse --show-toplevel)
  REPO=$(realpath "$REPO")
  [[ -f "$REPO/sdk/src/Core/AWSSDK.Core.NetStandard.csproj" ]] || { echo "$REPO is not an aws-sdk-net checkout" >&2; exit 2; }
  WT_ROOT=$(realpath -m "${AB_WORKTREES:-$HOME/code/perf-ab-worktrees}")
  LOCK=${AB_LOCK:-/tmp/core-bench.lock}

  local NPROC MAX_LOAD LOAD_WAIT
  NPROC=$(nproc)
  MAX_LOAD=${AB_MAX_LOAD:-$(( NPROC / 8 > 2 ? NPROC / 8 : 2 ))}
  LOAD_WAIT=${AB_LOAD_WAIT:-1800}

  # Resolve refs once, at start. A branch that moves later does not affect this run.
  local BASE_SHA PR_SHA B12 P12
  BASE_SHA=$(git -C "$REPO" rev-parse --verify "$BASE_REF^{commit}")
  PR_SHA=$(git -C "$REPO" rev-parse --verify "$PR_REF^{commit}")
  B12=${BASE_SHA:0:12}; P12=${PR_SHA:0:12}
  [[ -n "$OUT" ]] || OUT="$PWD/ab-results/${B12}-${P12}-$(date -u +%Y%m%dT%H%M%SZ)"
  mkdir -p "$OUT"
  OUT=$(cd -P "$OUT" && pwd -P)

  if [[ $BACKGROUND == 1 ]]; then
    # setsid puts the run in its own session, so it survives the calling shell exiting.
    # A plain `nohup ... &` from an agent's shell tool is killed when the tool call returns.
    # The child gets SHAs, so it cannot move with a branch; pass the names along for meta.json.
    AB_BASE_REF_NAME=${AB_BASE_REF_NAME:-$BASE_REF} AB_PR_REF_NAME=${AB_PR_REF_NAME:-$PR_REF} \
    setsid nohup "$SCRIPT_PATH" "$BASE_SHA" "$PR_SHA" "$FILTER" \
      --sdk-repo "$REPO" --runtimes "$RUNTIMES" --rounds "$ROUNDS" --job "$JOB" --out "$OUT" \
      $([[ $KEEP == 1 ]] && echo --keep-worktrees) \
      > "$OUT/ab.log" 2>&1 < /dev/null &
    local pid=$!
    echo "$pid" > "$OUT/ab.pid"
    echo "ab.sh running in background: pid $pid"
    echo "log:     $OUT/ab.log"
    echo "summary: $OUT/summary.md (written when the run finishes; ab.log ends with 'summary:' or an error)"
    return 0
  fi

  log() { echo "[ab] $(date -u +%H:%M:%S) $*" >&2; }

  # Copy the helper scripts into the output directory now. The summary step uses these
  # copies, so switching branches in the calling worktree mid-run cannot break it.
  cp "$SCRIPT_DIR/compare.py" "$OUT/compare.py"
  cp "$SCRIPT_PATH" "$OUT/ab.sh"

  # Snapshot the benchmark source now. Both sides build this copy, and it is what record.sh
  # stores with the results, so later edits to CoreBenchmarks/ cannot change this run.
  rm -rf "$OUT/bench-src"
  rsync -a --exclude bin/ --exclude obj/ --exclude BenchmarkDotNet.Artifacts/ --exclude .bdn/ "$SCRIPT_DIR/CoreBenchmarks/" "$OUT/bench-src/"
  local BENCH_SHA BENCH_DIRTY=false
  BENCH_SHA=$(git -C "$SCRIPT_DIR" rev-parse HEAD 2>/dev/null || echo unknown)
  [[ -n "$(git -C "$SCRIPT_DIR" status --porcelain -- CoreBenchmarks 2>/dev/null)" ]] && BENCH_DIRTY=true
  jq -n --arg base "$BASE_SHA" --arg base_ref "${AB_BASE_REF_NAME:-$BASE_REF}" --arg pr "$PR_SHA" --arg pr_ref "${AB_PR_REF_NAME:-$PR_REF}" \
        --arg filter "$FILTER" --arg runtimes "$RUNTIMES" --argjson rounds "$ROUNDS" --arg job "$JOB" \
        --arg bench "$BENCH_SHA" --argjson dirty "$BENCH_DIRTY" --arg started "$(date -u +%Y-%m-%dT%H:%M:%SZ)" \
        '{sdk: {base: $base, base_ref: $base_ref, pr: $pr, pr_ref: $pr_ref},
          benchmarks: {commit: $bench, uncommitted_changes: $dirty},
          filter: $filter, runtimes: ($runtimes | split(" ")), rounds: $rounds, job: $job, started: $started}' \
        > "$OUT/meta.json"
  # Per-run worktrees. Two runs with the same base SHA used to share one worktree, and the
  # second run would reset it and overwrite its benchmark source while the first was measuring.
  # REPO, RUN_WT, BASE_WT, PR_WT and KEEP are globals because the EXIT trap reads them.
  local RUN_ID BENCH_BASE BENCH_PR
  RUN_ID="$(date -u +%Y%m%dT%H%M%SZ)-$$-${B12:0:8}-${P12:0:8}"
  RUN_WT="$WT_ROOT/run-$RUN_ID"
  BASE_WT="$RUN_WT/base"
  PR_WT="$RUN_WT/pr"
  BENCH_BASE="$RUN_WT/bench-base"
  BENCH_PR="$RUN_WT/bench-pr"
  mkdir -p "$RUN_WT"

  cleanup() {
    local status=$?
    if [[ $KEEP == 1 ]]; then
      log "keeping worktrees under $RUN_WT"
    else
      for wt in "$BASE_WT" "$PR_WT"; do
        [[ -d "$wt" ]] && git -C "$REPO" worktree remove --force "$wt" 2>/dev/null || true
      done
      rm -rf "$RUN_WT/bench-base" "$RUN_WT/bench-pr"
      rmdir "$RUN_WT" 2>/dev/null || true
      git -C "$REPO" worktree prune 2>/dev/null || true
    fi
    return $status
  }
  trap cleanup EXIT

  log "run $RUN_ID"
  log "base $BASE_SHA -> $BASE_WT"
  git -C "$REPO" worktree add --quiet --detach "$BASE_WT" "$BASE_SHA"
  log "pr   $PR_SHA -> $PR_WT"
  git -C "$REPO" worktree add --quiet --detach "$PR_WT" "$PR_SHA"

  # One copy of the benchmark project per side, each pinned to its worktree. The pin is a
  # Directory.Build.props rather than a command-line property because BenchmarkDotNet
  # rebuilds the project itself, and that build must reference the same Core.
  local side wt bench
  for side in base pr; do
    wt=$BASE_WT; bench=$BENCH_BASE; [[ $side == pr ]] && { wt=$PR_WT; bench=$BENCH_PR; }
    rsync -a "$OUT/bench-src/" "$bench/"
    cat > "$bench/Directory.Build.props" <<PROPS
<Project>
  <PropertyGroup>
    <AwsSdkNetRoot>$wt/</AwsSdkNetRoot>
  </PropertyGroup>
</Project>
PROPS
  done

  for side in base pr; do
    bench=$BENCH_BASE; [[ $side == pr ]] && bench=$BENCH_PR
    log "building $side"
    dotnet build "$bench/CoreBenchmarks.csproj" -c Release -nologo -v q > "$OUT/build-$side.log" 2>&1 \
      || { echo "Build failed for $side, see $OUT/build-$side.log" >&2; tail -20 "$OUT/build-$side.log" >&2; exit 1; }
  done

  # Average number of runnable tasks other than this sampler, over 10 samples in 5 seconds.
  # Unlike the 1-minute load average this does not lag, so it is not inflated by the
  # benchmark run that just finished, but it does see other builds and tests running now.
  busy_now() {
    local i total=0 n
    for ((i = 0; i < 10; i++)); do
      n=$(awk '/^procs_running/ { print $2 }' /proc/stat)
      total=$(( total + n - 1 ))
      sleep 0.5
    done
    awk -v t="$total" 'BEGIN { v = t / 10; printf "%.1f", (v < 0 ? 0 : v) }'
  }

  # Waits until the machine is quiet enough to measure, and records how busy it was at the start.
  wait_for_quiet() {
    local dest=$1 waited=0 busy
    busy=$(busy_now)
    while awk -v l="$busy" -v m="$MAX_LOAD" 'BEGIN { exit !(l > m) }'; do
      if (( waited >= LOAD_WAIT )); then
        log "$busy other runnable tasks, still above $MAX_LOAD after ${waited}s; measuring anyway (flagged in summary)"
        break
      fi
      (( waited == 0 )) && log "$busy other runnable tasks, above $MAX_LOAD; waiting (up to ${LOAD_WAIT}s)"
      sleep 10; waited=$(( waited + 15 ))
      busy=$(busy_now)
    done
    printf 'load1=%s max=%s waited=%s\n' "$busy" "$MAX_LOAD" "$waited" > "$dest/load.txt"
  }

  run_side() {
    local side=$1 round=$2 bench=$3 tfm art
    for tfm in $RUNTIMES; do
      art="$OUT/round$round/$side/$tfm"
      mkdir -p "$art"
      wait_for_quiet "$art"
      log "round $round/$ROUNDS: $side ($tfm), $(cat "$art/load.txt")"
      # Each runtime runs as the BDN host process (-f), so any TFM the project targets works,
      # including ones BenchmarkDotNet has no --runtimes moniker for yet.
      ( cd "$bench" && dotnet run -c Release -f "$tfm" --no-build -- \
          --filter "$FILTER" --job "$JOB" --memory --exporters json --artifacts "$art" ) > "$art/run.log" 2>&1 \
        || { echo "Benchmark run failed ($side, $tfm, round $round), see $art/run.log" >&2; tail -30 "$art/run.log" >&2; exit 1; }
      if ! ls "$art"/results/*-report-full-compressed.json > /dev/null 2>&1; then
        echo "No BDN results for $side ($tfm, round $round); check the filter. See $art/run.log" >&2
        tail -30 "$art/run.log" >&2
        exit 1
      fi
    done
  }

  log "waiting for benchmark lock $LOCK"
  exec 9>"$LOCK"
  flock 9
  log "lock acquired"
  local r
  for ((r = 1; r <= ROUNDS; r++)); do
    run_side base "$r" "$BENCH_BASE"
    run_side pr "$r" "$BENCH_PR"
  done
  flock -u 9
  exec 9>&-

  python3 "$OUT/compare.py" "$OUT" --base "$BASE_SHA" --pr "$PR_SHA" --filter "$FILTER" \
    --bench "$BENCH_SHA$([[ $BENCH_DIRTY == true ]] && echo ' (plus uncommitted changes)')" > "$OUT/summary.md"
  log "summary: $OUT/summary.md"
  cat "$OUT/summary.md"
}

main "$@"
