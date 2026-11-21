# Benchmarks for normj/aws-sdk-net#35

PR: [perf(core): parse JSON epoch-second timestamps without decimal on .NET 8+](https://github.com/normj/aws-sdk-net/pull/35)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [json-epoch-parse-screen](json-epoch-parse-screen/summary.md) | 2026-11-21 | `0aa28435d63` | `63acef10855` | `8687b43f20b` |  |
| [json-epoch-parse-full](json-epoch-parse-full/summary.md) | 2026-11-21 | `0aa28435d63` | `63acef10855` | `8687b43f20b` |  |
