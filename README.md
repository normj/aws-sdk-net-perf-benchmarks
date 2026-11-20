# aws-sdk-net-perf-benchmarks

BenchmarkDotNet microbenchmarks and A/B tooling for performance work on `AWSSDK.Core` in the
[AWS SDK for .NET](https://github.com/aws/aws-sdk-net), done on the fork
[normj/aws-sdk-net](https://github.com/normj/aws-sdk-net).

The benchmarks live here, not in the SDK repo, so performance PRs contain only the product
change, its unit tests and its DevConfig file. Every PR's measurements are kept on a branch of
this repo so they can be reproduced or re-run later.

## Layout

| Path | Purpose |
|---|---|
| `CoreBenchmarks/` | BenchmarkDotNet project. Targets `net10.0;net11.0` and references `AWSSDK.Core.NetStandard.csproj` from an aws-sdk-net checkout. |
| `CoreBenchmarks/Benchmarks/*.cs` | One class per area, for example `SigningBenchmarks.cs`. Always `[MemoryDiagnoser]`. |
| `ab.sh` | Builds the benchmarks against two aws-sdk-net commits and runs interleaved A/B rounds. |
| `compare.py` | Turns the BenchmarkDotNet JSON reports into the markdown table for the PR description. |
| `record.sh` | Commits a run's results to the `pr/<n>-<name>` branch for that PR. |

### Branches

- **`main`**: the tooling and the shared benchmark classes. Add or improve a benchmark class here,
  so every later PR in that area measures with it.
- **`pr/<n>-<name>`**: one per SDK PR, for example `pr/4-core-signing-compress-spaces`. Created by
  `record.sh` and never merged back. Each holds `results/<run>/` with the `summary.md` posted in the
  PR, `meta.json` (the exact SDK base and PR SHAs and the options used), `bench-src/` (the
  benchmark source that was measured), and the raw BenchmarkDotNet JSON for every round.

## Prerequisites

- .NET 10 and .NET 11 SDKs
- `git`, `python3`, `jq`, `rsync`, `flock` (util-linux)
- `gh`, authenticated, for `record.sh`
- An aws-sdk-net checkout. By default the scripts look for `../aws-sdk-net` next to this repo;
  set `AWS_SDK_NET_REPO` or pass `--sdk-repo` otherwise.

## Running an A/B comparison

```bash
./ab.sh <base-ref> <pr-ref> '<bdn-filter>'
# example: the PR branch against fork main
./ab.sh origin/main perf/core-signing-foo '*SigningBenchmarks*'
```

The refs are resolved in the aws-sdk-net checkout. The benchmark source is `CoreBenchmarks/` from
this repo's working tree at the moment the run starts, so you can try a new benchmark class
before committing it. `meta.json` records whether it had uncommitted changes.

Defaults: runtimes `net10.0 net11.0`, 3 interleaved rounds (base, PR, base, PR, base, PR),
MemoryDiagnoser, and fixed BenchmarkDotNet counts: 3 warmup and 10 measured iterations of 250 ms
each, run in-process (`--inProcess`) so BenchmarkDotNet does not rebuild a project for every
invocation. A full run of `SigningBenchmarks` takes about 5.5 minutes. Options: `--rounds`,
`--runtimes`, `--warmups`, `--iterations`, `--iteration-ms`, `--toolchain outofprocess`
(BenchmarkDotNet's normal mode), `--job Short` or `--job Dry` (quick local checks only),
`--screen`, `--out`, `--sdk-repo`, `--background`, `--keep-worktrees`.

These settings were checked before use. With the same commit on both sides, every row came out
`same`, within 2%. PR #4's known win measured 9% to 10% faster with them, within 1% of its earlier
run with BenchmarkDotNet's adaptive defaults.

### Screen first, then measure

Every candidate gets a screening run before a full run:

```bash
./ab.sh origin/main perf/core-foo '*FooBenchmarks.Method*' --screen --out ~/code/perf-ab-results/foo-screen
```

`--screen` runs `net10.0` only, 1 round, 2 warmup and 6 measured iterations, in about a minute.
Its summary ends with `PROMISING` when some row is at least 5% faster or allocates at least 1%
less, and with `NOT PROMISING` otherwise. Only `PROMISING` candidates get the full run, and
only the full run's numbers go in a PR. Filter both runs to the benchmark methods the change
can affect: every extra method adds about 20 seconds per invocation.

### Running in the background

A full run takes 15 to 30 minutes. From an agent's shell tool, start it with `--background`:

```bash
./ab.sh origin/main perf/core-signing-foo '*SigningBenchmarks*' \
  --out ~/code/perf-ab-results/signing/foo --background
# poll until the log ends with "summary:" (success) or an error
tail -3 ~/code/perf-ab-results/signing/foo/ab.log
```

`--background` runs the script under `setsid nohup`, writes `ab.log` and `ab.pid` to the output
directory and returns immediately. Do not use a plain `nohup ... &`: the run is killed when the
shell tool call returns.

### What the script does

1. Resolves both refs to SHAs at start, so a branch that moves later does not affect the run.
2. Copies `ab.sh`, `compare.py` and `CoreBenchmarks/` into the output directory and uses those
   copies. Editing the scripts or benchmarks, or switching branches here, cannot change a run in
   progress. It also writes `meta.json`.
3. Creates a fresh pair of detached aws-sdk-net worktrees for this run under
   `~/code/perf-ab-worktrees/run-<id>/` (override with `AB_WORKTREES`) and removes them when the
   run exits. Pass `--keep-worktrees` to keep them. Concurrent runs never share files. Each
   running run needs about 3.5 GB of disk.
4. Makes one copy of the benchmark project per side, pinned to that side's worktree by a
   `Directory.Build.props`, so both sides run identical benchmark code and only `AWSSDK.Core`
   differs. Benchmarks must therefore only call APIs that exist on the base commit.
5. Builds only the benchmark project and its references on each side, never the whole SDK.
6. Takes an exclusive lock (`/tmp/core-bench.lock`, override with `AB_LOCK`) for the measurement
   phase, so only one benchmark runs on the machine at a time. Setup and builds happen outside
   the lock.
7. Before each measurement, waits until the machine is quiet: the number of other runnable tasks,
   averaged over 5 seconds, must be at or below `AB_MAX_LOAD` (default `nproc / 8`, minimum 2). It
   waits up to `AB_LOAD_WAIT` seconds (default 1800), then measures anyway and flags that
   measurement in the summary.
8. Writes `summary.md` to the output directory.

### Reading the summary

- **Time** is `faster` or `slower` only when the median changes by at least 5% and every PR round
  beats (or loses to) every base round. Anything else is `same`.
- **Alloc** is `less` or `more` under the same rule with a 1% threshold. Allocation is close to
  deterministic, so a small consistent change is real.
- **Overall** is `win` when at least one row is `faster` or `less` and none is `slower` or `more`.
  That is the bar for opening a perf PR. It is `regression` when any row is `slower` or `more`,
  and `no measurable change` otherwise.
- A warning block appears if any measurement started while the machine was busy. Treat time
  numbers from such a run as noisy and re-run it.

### Keeping the machine quiet

Other heavy work on the host (unit test runs, reviewer builds, `git gc`) skews timings. Run heavy
commands through `with-test-lock.sh`:

```bash
./with-test-lock.sh dotnet test sdk/test/UnitTests/AWSSDK.UnitTests.Core.csproj -c Release -f net10.0
```

These commands share the lock, so any number can run at once, and they never overlap a
measurement. A queued benchmark has priority: new commands wait until it has measured. Don't use a
plain `flock /tmp/core-bench.lock <cmd>`: it serializes all tests, and the C# compiler server that
`dotnet` starts inherits the lock and keeps it after the command ends.

This only waits between whole A/B runs, not between rounds. The quiet-machine check in step 7
covers work that does not take the lock.

## Recording results for a PR

After the PR is open, record every run that its description cites:

```bash
./record.sh 4 ~/code/perf-ab-results/signing/compress-spaces
# several runs at once, with a note
./record.sh 2 ~/code/perf-ab-results/signing/c1b-vs-base ~/code/perf-ab-results/signing/c1b-vs-prev \
  --note "after review fix"
```

`record.sh` creates or updates `pr/<n>-<name>` from `origin/main`, copies the results (not the
logs), scans them for anything that should not be public, commits and pushes. Link the branch's
`results/` folder from the PR description, and keep the benchmark source and table in the
description too, so reviewers on the upstream repo have them inline.

## Rules for perf PRs

- No public or protected API changes, including in `*.Internal` namespaces. Service packages
  compiled against older Core versions call those members.
- No behavior changes, including retry timing and credential refresh.
- Pool or cache only when nothing pooled or cached is reachable by callers.
- No new `unsafe` code. Prefer BCL primitives (`SearchValues`, `IndexOfAny`, `Ascii`, span-based
  APIs). .NET 10+ fast paths go behind `#if NET10_0_OR_GREATER`; `netstandard2.0` and `net8.0`
  must still compile and pass tests.
- The PR contains only `sdk/src/Core/**`, `sdk/test/UnitTests/**` and `generator/.DevConfigs/**`.
  Check with `git diff --stat origin/main...HEAD` before pushing. No benchmark or workflow files.
- Open a PR only when `summary.md` says `Overall: win`.
- After review-driven changes, measure against both the base and the previous PR head.
- Each PR includes a DevConfig file with a Core patch bump, so it can go upstream unchanged.
- PR descriptions and comments end with the AI-agent signature line.

## PR description template

````markdown
## Summary
<one paragraph: what hot path, what was allocated or slow, what changed>

## Benchmark
Recorded runs: https://github.com/normj/aws-sdk-net-perf-benchmarks/tree/pr/<n>-<name>/results

<details><summary>Benchmark source</summary>

```csharp
<contents of the benchmark class used>
```
</details>

<paste summary.md from ab.sh here>

## Testing
- `AWSSDK.UnitTests.Core` on net8.0 / net10.0 / net11.0 (Perf CI on the fork)
- <any new unit tests>

🤖 Posted by AWS SDK .NET Perf (AI Agent)
````

## License

Apache License 2.0, the same as the AWS SDK for .NET. See [LICENSE](LICENSE).
