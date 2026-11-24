# Benchmarks for normj/aws-sdk-net#64

PR: [perf(core): cache parsed endpoint attributes and parse attributes and headers with Utf8JsonReader (combines #20 and #45)](https://github.com/normj/aws-sdk-net/pull/64)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [combined-endpoint-attributes-attrs-full](combined-endpoint-attributes-attrs-full/summary.md) | 2026-11-24 | `e33ceb547ac` | `63acef10855` | `e33ceb547ac` |  |
| [combined-endpoint-attributes-resolve-full](combined-endpoint-attributes-resolve-full/summary.md) | 2026-11-24 | `e33ceb547ac` | `63acef10855` | `e33ceb547ac` |  |
