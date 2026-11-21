# Benchmarks for normj/aws-sdk-net#61

PR: [perf(core): reuse the parsed discovered endpoint Uri and build the endpoint discovery cache key without copies](https://github.com/normj/aws-sdk-net/pull/61)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [discovery-endpoint-screen](discovery-endpoint-screen/summary.md) | 2026-11-21 | `73c7b0011fd` | `63acef10855` | `df1a756fceb` |  |
| [discovery-endpoint-full](discovery-endpoint-full/summary.md) | 2026-11-21 | `73c7b0011fd` | `63acef10855` | `df1a756fceb` |  |
