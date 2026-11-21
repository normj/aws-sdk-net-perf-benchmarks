# Benchmarks for normj/aws-sdk-net#22

PR: [perf(core): format ISO 8601 and RFC 822 timestamps with BCL fast paths on .NET 8+](https://github.com/normj/aws-sdk-net/pull/22)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [format-iso8601-screen](format-iso8601-screen/summary.md) | 2026-11-21 | `29ad1ce003c` | `63acef10855` | `ff81b2f7f24` |  |
| [format-iso8601-full](format-iso8601-full/summary.md) | 2026-11-21 | `29ad1ce003c` | `63acef10855` | `ff81b2f7f24` |  |
