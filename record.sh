#!/usr/bin/env bash
# Record ab.sh results for an aws-sdk-net PR on a branch of this repo.
#
# Usage:
#   record.sh <pr-number> <ab-out-dir> [<ab-out-dir> ...] [options]
#
# Options:
#   --sdk-repo-slug <owner/name>  GitHub repo the PR is on (default: normj/aws-sdk-net)
#   --note <text>                 Line added to the branch's results/README.md for these runs
#   --no-push                     Commit locally but do not push
#
# The branch is pr/<n>-<name>, where <name> is the PR's head branch without its
# perf/ prefix. It is created from origin/main the first time and gets one new
# commit per call after that. Each <ab-out-dir> is stored as results/<dir-name>/:
# summary.md, meta.json, bench-src/, and per round the BenchmarkDotNet JSON and
# GitHub-markdown reports plus load.txt. Logs and build output are not stored.
#
# Everything is scanned for credentials, internal host names and home-directory
# paths before committing, because this repo is public. A match stops the
# commit and lists the lines.

set -euo pipefail

main() {
  local SCRIPT_DIR
  SCRIPT_DIR=$(dirname "$(realpath "${BASH_SOURCE[0]}")")
  usage() { sed -n '2,22p' "${BASH_SOURCE[0]}" | sed 's/^# \{0,1\}//'; exit 2; }

  [[ $# -ge 2 ]] || usage
  local PR=$1; shift
  [[ $PR =~ ^[0-9]+$ ]] || { echo "PR number must be numeric: $PR" >&2; exit 2; }
  local SLUG=normj/aws-sdk-net NOTE="" PUSH=1 dirs=()
  while [[ $# -gt 0 ]]; do
    case "$1" in
      --sdk-repo-slug) SLUG=$2; shift 2 ;;
      --note) NOTE=$2; shift 2 ;;
      --no-push) PUSH=0; shift ;;
      -h|--help) usage ;;
      -*) echo "Unknown option: $1" >&2; usage ;;
      *) dirs+=("$1"); shift ;;
    esac
  done
  [[ ${#dirs[@]} -gt 0 ]] || usage
  local d
  for d in "${dirs[@]}"; do
    [[ -f "$d/summary.md" && -f "$d/meta.json" && -d "$d/bench-src" ]] \
      || { echo "$d is not a finished ab.sh output directory (needs summary.md, meta.json, bench-src/)" >&2; exit 2; }
  done

  local info head_ref head_sha title url name branch
  info=$(gh pr view "$PR" --repo "$SLUG" --json headRefName,headRefOid,title,url)
  head_ref=$(jq -r .headRefName <<<"$info"); head_sha=$(jq -r .headRefOid <<<"$info")
  title=$(jq -r .title <<<"$info"); url=$(jq -r .url <<<"$info")
  name=${head_ref#perf/}; name=${name//\//-}
  branch="pr/$PR-$name"

  local REPO WT
  REPO=$(git -C "$SCRIPT_DIR" rev-parse --show-toplevel)
  git -C "$REPO" fetch --quiet origin
  WT=$(mktemp -d "${TMPDIR:-/tmp}/record-pr$PR-XXXXXX")
  trap 'git -C "$REPO" worktree remove --force "$WT" 2>/dev/null || rm -rf "$WT"' EXIT
  if git -C "$REPO" rev-parse --verify --quiet "refs/remotes/origin/$branch" > /dev/null; then
    git -C "$REPO" worktree add --quiet -B "$branch" "$WT" "origin/$branch"
  else
    git -C "$REPO" worktree add --quiet -B "$branch" "$WT" origin/main
  fi

  mkdir -p "$WT/results"
  local dest name_d
  for d in "${dirs[@]}"; do
    name_d=$(basename "$(realpath "$d")")
    dest="$WT/results/$name_d"
    rm -rf "$dest"; mkdir -p "$dest"
    cp "$d/summary.md" "$d/meta.json" "$dest/"
    rsync -a "$d/bench-src/" "$dest/bench-src/"
    ( cd "$d" && find . -path './round*' \( -name '*-report-full-compressed.json' -o -name '*-report-github.md' -o -name load.txt \) -print0 \
        | rsync -a --from0 --files-from=- ./ "$dest/" )
  done

  # Publish-safety scan. The repo is public.
  local pattern='AKIA[0-9A-Z]{16}|ASIA[0-9A-Z]{16}|aws_secret_access_key|aws_session_token|BEGIN [A-Z ]*PRIVATE KEY|ghp_[A-Za-z0-9]{20,}|gho_[A-Za-z0-9]{20,}|amazon\.com|amazon\.dev|a2z\.com|corp\.[a-z]|dev-dsk|midway|/local/home/|/home/[a-z]'
  local hits
  hits=$(grep -rInE "$pattern" "$WT/results" || true)
  if [[ -n "$hits" ]]; then
    echo "Refusing to commit: these lines look private (credentials, internal hosts, or home paths):" >&2
    echo "$hits" | sed "s|$WT/||" | head -40 >&2
    exit 1
  fi

  local readme="$WT/results/README.md"
  if [[ ! -f "$readme" ]]; then
    {
      echo "# Benchmarks for $SLUG#$PR"
      echo
      echo "PR: [$title]($url)"
      echo
      echo "Each directory is one ab.sh run: \`summary.md\` is the table posted in the PR, \`meta.json\` has the"
      echo "exact aws-sdk-net SHAs and options, and \`bench-src/\` is the benchmark source that was measured."
      echo
      echo "| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |"
      echo "|---|---|---|---|---|---|"
    } > "$readme"
  fi
  for d in "${dirs[@]}"; do
    name_d=$(basename "$(realpath "$d")")
    printf '| [%s](%s/summary.md) | %s | `%s` | `%s` | `%s` | %s |\n' "$name_d" "$name_d" "$(date -u +%Y-%m-%d)" \
      "${head_sha:0:11}" "$(jq -r '.sdk.base[0:11]' "$d/meta.json")" "$(jq -r '.sdk.pr[0:11]' "$d/meta.json")" "$NOTE" >> "$readme"
  done

  git -C "$WT" add -A results
  if git -C "$WT" diff --cached --quiet; then
    echo "Nothing new to record on $branch"
    return 0
  fi
  git -C "$WT" commit --quiet -m "Benchmarks for $SLUG#$PR ($head_ref @ ${head_sha:0:11})

$(for d in "${dirs[@]}"; do echo "- $(basename "$(realpath "$d")")"; done)"
  if [[ $PUSH == 1 ]]; then
    git -C "$WT" push --quiet -u origin "$branch"
    local self
    self=$(cd "$REPO" && gh repo view --json nameWithOwner -q .nameWithOwner 2>/dev/null || git -C "$REPO" remote get-url origin)
    echo "recorded: https://github.com/${self#https://github.com/}/tree/$branch/results"
  else
    echo "committed locally on $branch (not pushed)"
  fi
}

main "$@"
