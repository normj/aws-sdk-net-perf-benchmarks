# Benchmarks for normj/aws-sdk-net#16

PR: [perf(core): reuse lowercased SigV4 header names](https://github.com/normj/aws-sdk-net/pull/16)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [header-names-screen](header-names-screen/summary.md) | 2026-11-21 | `8d867ed6724` | `63acef10855` | `321ec6ee997` |  |
| [header-names-screen2](header-names-screen2/summary.md) | 2026-11-21 | `8d867ed6724` | `63acef10855` | `321ec6ee997` |  |
| [header-names-full](header-names-full/summary.md) | 2026-11-21 | `8d867ed6724` | `63acef10855` | `321ec6ee997` |  |
