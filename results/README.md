# Benchmarks for normj/aws-sdk-net#26

PR: [perf(core): look up the supported auth scheme without LINQ in BaseAuthResolverHandler](https://github.com/normj/aws-sdk-net/pull/26)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [auth-scheme-lookup-v2-screen](auth-scheme-lookup-v2-screen/summary.md) | 2026-11-21 | `67b080dcfb5` | `63acef10855` | `9f4a221d036` |  |
| [auth-scheme-lookup-v2-full](auth-scheme-lookup-v2-full/summary.md) | 2026-11-21 | `67b080dcfb5` | `63acef10855` | `9f4a221d036` |  |
