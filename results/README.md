# Benchmarks for normj/aws-sdk-net#46

PR: [perf(core): build the signed upload trailer with fewer strings and encode it once](https://github.com/normj/aws-sdk-net/pull/46)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [trailer-chunk-screen](trailer-chunk-screen/summary.md) | 2026-11-21 | `ac6da37aaa6` | `63acef10855` | `2580be3a30c` |  |
| [trailer-chunk-full](trailer-chunk-full/summary.md) | 2026-11-21 | `ac6da37aaa6` | `63acef10855` | `2580be3a30c` |  |
