# Benchmarks for normj/aws-sdk-net#10

PR: [perf(core): parse endpoint ARNs without string.Split and reject non-ARNs with an ordinal check](https://github.com/normj/aws-sdk-net/pull/10)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [arn-parse-screen](arn-parse-screen/summary.md) | 2026-11-20 | `9480c4fe832` | `63acef10855` | `f5d7f350292` |  |
| [arn-parse-full](arn-parse-full/summary.md) | 2026-11-20 | `9480c4fe832` | `63acef10855` | `f5d7f350292` |  |
