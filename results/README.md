# Benchmarks for normj/aws-sdk-net#6

PR: [perf(core): return the inner task directly from pass-through async pipeline handlers](https://github.com/normj/aws-sdk-net/pull/6)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [async-elide-screen](async-elide-screen/summary.md) | 2026-11-20 | `52c2792aa14` | `63acef10855` | `95d78344669` |  |
| [async-elide-full](async-elide-full/summary.md) | 2026-11-20 | `52c2792aa14` | `63acef10855` | `7a5f7737faa` |  |
