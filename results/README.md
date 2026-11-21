# Benchmarks for normj/aws-sdk-net#57

PR: [perf(core): measure per-request telemetry durations with a struct instead of an allocated measurer](https://github.com/normj/aws-sdk-net/pull/57)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [telemetry-duration-struct-screen](telemetry-duration-struct-screen/summary.md) | 2026-11-21 | `cf0ca324877` | `63acef10855` | `d510effa73f` |  |
| [telemetry-duration-struct-full](telemetry-duration-struct-full/summary.md) | 2026-11-21 | `cf0ca324877` | `63acef10855` | `d510effa73f` |  |
