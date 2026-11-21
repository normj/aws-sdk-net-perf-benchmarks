# Benchmarks for normj/aws-sdk-net#34

PR: [perf(core): cache parsed endpoint URL templates in Fn.Interpolate](https://github.com/normj/aws-sdk-net/pull/34)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [interpolate-template-cache-screen](interpolate-template-cache-screen/summary.md) | 2026-11-21 | `2903be61458` | `63acef10855` | `bae3f9427bb` |  |
| [interpolate-template-cache-full](interpolate-template-cache-full/summary.md) | 2026-11-21 | `2903be61458` | `63acef10855` | `bae3f9427bb` |  |
| [interpolate-template-cache-resolve-full](interpolate-template-cache-resolve-full/summary.md) | 2026-11-21 | `2903be61458` | `63acef10855` | `bae3f9427bb` |  |
