# Benchmarks for normj/aws-sdk-net#62

PR: [perf(core): reuse telemetry name strings and measure request durations with a struct](https://github.com/normj/aws-sdk-net/pull/62)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [combined-telemetry-full](combined-telemetry-full/summary.md) | 2026-11-24 | `4759f8d42c9` | `63acef10855` | `4759f8d42c9` |  |
