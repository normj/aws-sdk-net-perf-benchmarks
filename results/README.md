# Benchmarks for normj/aws-sdk-net#63

PR: [perf(core): create DefaultRequest collections on first use and skip unused before-request event args (combines #31 and #48)](https://github.com/normj/aws-sdk-net/pull/63)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [combined-lazy-default-request-full3](combined-lazy-default-request-full3/summary.md) | 2026-11-24 | `742f5920e60` | `63acef10855` | `742f5920e60` |  |
| [combined-lazy-default-request-full](combined-lazy-default-request-full/summary.md) | 2026-11-24 | `742f5920e60` | `63acef10855` | `742f5920e60` |  |
