# Benchmarks for normj/aws-sdk-net#25

PR: [perf(core): reuse telemetry scope, operation and span name strings when a telemetry provider is set](https://github.com/normj/aws-sdk-net/pull/25)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [telemetry-names-screen](telemetry-names-screen/summary.md) | 2026-11-21 | `c564c607a33` | `63acef10855` | `8a7965d1f58` |  |
| [telemetry-names-full](telemetry-names-full/summary.md) | 2026-11-21 | `c564c607a33` | `63acef10855` | `8a7965d1f58` |  |
