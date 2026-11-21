# Benchmarks for normj/aws-sdk-net#43

PR: [perf(core): sign SigV4 upload chunks without per-chunk strings on .NET 8+](https://github.com/normj/aws-sdk-net/pull/43)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [chunk-sign-screen](chunk-sign-screen/summary.md) | 2026-11-21 | `01994d20f62` | `63acef10855` | `b69cf226b60` |  |
| [chunk-sign-full](chunk-sign-full/summary.md) | 2026-11-21 | `01994d20f62` | `63acef10855` | `b69cf226b60` |  |
