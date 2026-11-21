# Benchmarks for normj/aws-sdk-net#24

PR: [perf(core): look up single-segment GetAttr paths with the caller's string](https://github.com/normj/aws-sdk-net/pull/24)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [getattr-single-screen](getattr-single-screen/summary.md) | 2026-11-21 | `2cfbf9f2dd4` | `63acef10855` | `a9f0d91da8d` | Measured at a9f0d91; the PR head adds only the DevConfig |
| [getattr-single-full](getattr-single-full/summary.md) | 2026-11-21 | `2cfbf9f2dd4` | `63acef10855` | `a9f0d91da8d` | Measured at a9f0d91; the PR head adds only the DevConfig |
| [getattr-single-resolve-full](getattr-single-resolve-full/summary.md) | 2026-11-21 | `2cfbf9f2dd4` | `63acef10855` | `a9f0d91da8d` | Measured at a9f0d91; the PR head adds only the DevConfig |
