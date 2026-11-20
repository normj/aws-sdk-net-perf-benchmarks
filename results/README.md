# Benchmarks for normj/aws-sdk-net#7

PR: [perf(core): build the SigV4 canonical resource path in one pass](https://github.com/normj/aws-sdk-net/pull/7)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [resource-path-screen2a](resource-path-screen2a/summary.md) | 2026-11-20 | `930030980b1` | `63acef10855` | `d5e9c7f38fb` |  |
| [resource-path-screen2b](resource-path-screen2b/summary.md) | 2026-11-20 | `930030980b1` | `63acef10855` | `d5e9c7f38fb` |  |
| [resource-path-full](resource-path-full/summary.md) | 2026-11-20 | `930030980b1` | `63acef10855` | `d5e9c7f38fb` |  |
