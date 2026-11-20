# Benchmarks for normj/aws-sdk-net#11

PR: [perf(core): check endpoint Substring input for non-ASCII characters without LINQ](https://github.com/normj/aws-sdk-net/pull/11)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [substring-no-linq-screen](substring-no-linq-screen/summary.md) | 2026-11-20 | `773420e780e` | `63acef10855` | `431971032f0` |  |
| [substring-no-linq-full](substring-no-linq-full/summary.md) | 2026-11-20 | `773420e780e` | `63acef10855` | `431971032f0` |  |
