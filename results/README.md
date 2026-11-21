# Benchmarks for normj/aws-sdk-net#27

PR: [perf(core): look up the supported auth scheme without LINQ in BaseAuthResolverHandler](https://github.com/normj/aws-sdk-net/pull/27)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [auth-scheme-lookup-screen](auth-scheme-lookup-screen/summary.md) | 2026-11-21 | `5d55b035058` | `63acef10855` | `521d51b06ff` |  |
| [auth-scheme-lookup-screen2](auth-scheme-lookup-screen2/summary.md) | 2026-11-21 | `5d55b035058` | `63acef10855` | `521d51b06ff` |  |
| [auth-scheme-lookup-full](auth-scheme-lookup-full/summary.md) | 2026-11-21 | `5d55b035058` | `63acef10855` | `521d51b06ff` |  |
