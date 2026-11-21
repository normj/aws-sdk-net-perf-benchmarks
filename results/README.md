# Benchmarks for normj/aws-sdk-net#21

PR: [perf(core): skip building exception details for the no-op trace span on failed requests](https://github.com/normj/aws-sdk-net/pull/21)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [noop-capture-exception-screen](noop-capture-exception-screen/summary.md) | 2026-11-21 | `f3e69d694f8` | `63acef10855` | `862cb393ed1` |  |
| [noop-capture-exception-full](noop-capture-exception-full/summary.md) | 2026-11-21 | `f3e69d694f8` | `63acef10855` | `862cb393ed1` |  |
| [noop-capture-exception-full2](noop-capture-exception-full2/summary.md) | 2026-11-21 | `f3e69d694f8` | `63acef10855` | `f3e69d694f8` |  |
