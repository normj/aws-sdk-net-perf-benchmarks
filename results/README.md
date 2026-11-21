# Benchmarks for normj/aws-sdk-net#20

PR: [perf(core): parse endpoint attributes and headers with Utf8JsonReader instead of JsonDocument](https://github.com/normj/aws-sdk-net/pull/20)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [endpoint-reader-screen](endpoint-reader-screen/summary.md) | 2026-11-21 | `a65a6aaff66` | `63acef10855` | `d4ad7078119` | Measured at d4ad707; the PR head adds only the DevConfig |
| [endpoint-reader-full](endpoint-reader-full/summary.md) | 2026-11-21 | `a65a6aaff66` | `63acef10855` | `d4ad7078119` | Measured at d4ad707; the PR head adds only the DevConfig |
| [endpoint-reader-resolve-full](endpoint-reader-resolve-full/summary.md) | 2026-11-21 | `a65a6aaff66` | `63acef10855` | `d4ad7078119` | Measured at d4ad707; the PR head adds only the DevConfig |
