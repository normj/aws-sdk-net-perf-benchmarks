# Benchmarks for normj/aws-sdk-net#19

PR: [perf(core): cache CachingWrapperStream reads without a temporary array per read](https://github.com/normj/aws-sdk-net/pull/19)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [caching-stream-no-copy-screen](caching-stream-no-copy-screen/summary.md) | 2026-11-21 | `f9c6bff8472` | `63acef10855` | `d5847810ee5` |  |
| [caching-stream-no-copy-full](caching-stream-no-copy-full/summary.md) | 2026-11-21 | `f9c6bff8472` | `63acef10855` | `d5847810ee5` |  |
