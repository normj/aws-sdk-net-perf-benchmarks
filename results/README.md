# Benchmarks for normj/aws-sdk-net#3

PR: [perf(core): format SigV4 dates and the string to sign without intermediate strings](https://github.com/normj/aws-sdk-net/pull/3)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [01-initial](01-initial/summary.md) | 2026-11-20 | `1da11598e20` | `ab7f1c8a3f2` | `f5ee0c95781` | Pilot; product code identical to the current head |
