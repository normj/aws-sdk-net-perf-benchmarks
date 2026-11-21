# Benchmarks for normj/aws-sdk-net#36

PR: [perf(core): decode UnmarshallerContext.ResponseBody from the cached bytes without copying them first on .NET 8+](https://github.com/normj/aws-sdk-net/pull/36)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [response-body-span-screen](response-body-span-screen/summary.md) | 2026-11-21 | `3a3110cc1af` | `63acef10855` | `7e692221b9d` |  |
| [response-body-span-full](response-body-span-full/summary.md) | 2026-11-21 | `3a3110cc1af` | `63acef10855` | `7e692221b9d` |  |
