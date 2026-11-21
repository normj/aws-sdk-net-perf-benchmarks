# Benchmarks for normj/aws-sdk-net#59

PR: [perf(core): remove per-attempt allocations for the amz-sdk-request header, clock skew store and uncancelable body registrations](https://github.com/normj/aws-sdk-net/pull/59)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [attempt-allocs-screen](attempt-allocs-screen/summary.md) | 2026-11-21 | `1c60db6c1f5` | `63acef10855` | `58e19a7bd55` |  |
| [attempt-allocs-full](attempt-allocs-full/summary.md) | 2026-11-21 | `1c60db6c1f5` | `63acef10855` | `58e19a7bd55` |  |
