# Benchmarks for normj/aws-sdk-net#54

PR: [perf(core): parse canonical Date response headers without DateTime.TryParseExact for clock skew recording](https://github.com/normj/aws-sdk-net/pull/54)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [date-header-parse-screen](date-header-parse-screen/summary.md) | 2026-11-21 | `2d88f8d5139` | `63acef10855` | `75d07ad44f2` |  |
| [date-header-parse-screen3](date-header-parse-screen3/summary.md) | 2026-11-21 | `2d88f8d5139` | `63acef10855` | `75d07ad44f2` |  |
| [date-header-parse-full](date-header-parse-full/summary.md) | 2026-11-21 | `2d88f8d5139` | `63acef10855` | `75d07ad44f2` |  |
