# Benchmarks for normj/aws-sdk-net#44

PR: [perf(core): avoid three throwaway allocations when building the HTTP request](https://github.com/normj/aws-sdk-net/pull/44)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [request-creation-screen](request-creation-screen/summary.md) | 2026-11-21 | `c083ad7e246` | `63acef10855` | `916cdb605c3` |  |
| [request-creation-full](request-creation-full/summary.md) | 2026-11-21 | `c083ad7e246` | `63acef10855` | `916cdb605c3` |  |
