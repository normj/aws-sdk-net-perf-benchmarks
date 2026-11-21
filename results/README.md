# Benchmarks for normj/aws-sdk-net#37

PR: [perf(core): skip sort and join for a single trailing checksum header](https://github.com/normj/aws-sdk-net/pull/37)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [trailer-headers-screen](trailer-headers-screen/summary.md) | 2026-11-21 | `6587d5b3b9b` | `63acef10855` | `05ef1d7349a` |  |
| [trailer-headers-full](trailer-headers-full/summary.md) | 2026-11-21 | `6587d5b3b9b` | `63acef10855` | `05ef1d7349a` |  |
