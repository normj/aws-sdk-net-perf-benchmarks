# Benchmarks for normj/aws-sdk-net#28

PR: [perf(core): compare unescaped ASCII JSON names directly in StreamingUtf8JsonReader.ValueTextEquals on .NET 8+](https://github.com/normj/aws-sdk-net/pull/28)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [json-valuetextequals-screen](json-valuetextequals-screen/summary.md) | 2026-11-21 | `e5441360c91` | `63acef10855` | `f4c2f05b664` |  |
| [json-valuetextequals-full](json-valuetextequals-full/summary.md) | 2026-11-21 | `e5441360c91` | `63acef10855` | `f4c2f05b664` |  |
