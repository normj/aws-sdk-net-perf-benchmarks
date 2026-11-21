# Benchmarks for normj/aws-sdk-net#45

PR: [perf(core): cache parsed endpoint attributes and return deep copies](https://github.com/normj/aws-sdk-net/pull/45)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [endpoint-attr-cache-screen](endpoint-attr-cache-screen/summary.md) | 2026-11-21 | `fbb2509b265` | `63acef10855` | `f02057dd481` |  |
| [endpoint-attr-cache-full](endpoint-attr-cache-full/summary.md) | 2026-11-21 | `fbb2509b265` | `63acef10855` | `f02057dd481` |  |
| [endpoint-attr-cache-resolve-full](endpoint-attr-cache-resolve-full/summary.md) | 2026-11-21 | `fbb2509b265` | `63acef10855` | `f02057dd481` |  |
