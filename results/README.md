# Benchmarks for normj/aws-sdk-net#40

PR: [perf(core): skip error-path log arguments when no SDK log adaptor is enabled](https://github.com/normj/aws-sdk-net/pull/40)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [error-path-allocs-screen2](error-path-allocs-screen2/summary.md) | 2026-11-21 | `c5e4457f180` | `63acef10855` | `892b9f453e3` |  |
| [error-path-allocs-full](error-path-allocs-full/summary.md) | 2026-11-21 | `c5e4457f180` | `63acef10855` | `892b9f453e3` |  |
