# Benchmarks for normj/aws-sdk-net#2

PR: [perf(core): hash the SigV4 canonical request without materializing it as a string](https://github.com/normj/aws-sdk-net/pull/2)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [01-initial](01-initial/summary.md) | 2026-11-20 | `37aaf04a222` | `ab7f1c8a3f2` | `3cc5d5c3e77` | Pilot, first version (superseded by the review fix) |
