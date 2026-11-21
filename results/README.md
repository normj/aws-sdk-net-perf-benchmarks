# Benchmarks for normj/aws-sdk-net#14

PR: [perf(core): write the SigV4 Authorization header and presigned auth parameters in one pass](https://github.com/normj/aws-sdk-net/pull/14)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [result-strings-screen](result-strings-screen/summary.md) | 2026-11-21 | `0b7a9d36b90` | `63acef10855` | `d5b30f35c83` |  |
| [result-strings-full](result-strings-full/summary.md) | 2026-11-21 | `0b7a9d36b90` | `63acef10855` | `d5b30f35c83` |  |
