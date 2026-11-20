# Benchmarks for normj/aws-sdk-net#4

PR: [perf(core): vectorize the already-compact check in AWSSDKUtils.CompressSpaces](https://github.com/normj/aws-sdk-net/pull/4)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [01-initial](01-initial/summary.md) | 2026-11-20 | `9bdd2cea4df` | `ab7f1c8a3f2` | `f197dda7e9f` | Pilot; product code identical to the current head |
