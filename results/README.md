# Benchmarks for normj/aws-sdk-net#38

PR: [perf(core): reuse parsed custom endpoint URLs in Fn.ParseURL](https://github.com/normj/aws-sdk-net/pull/38)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [parseurl-cache-screen](parseurl-cache-screen/summary.md) | 2026-11-21 | `c20c7a78147` | `63acef10855` | `47b79b920ea` |  |
| [parseurl-cache-full](parseurl-cache-full/summary.md) | 2026-11-21 | `c20c7a78147` | `63acef10855` | `47b79b920ea` |  |
