# Benchmarks for normj/aws-sdk-net#52

PR: [perf(core): resolve REST resource paths in one pass in AWSSDKUtils.ResolveResourcePathV2](https://github.com/normj/aws-sdk-net/pull/52)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [resolve-path-screen](resolve-path-screen/summary.md) | 2026-11-21 | `9da2c0a98d8` | `63acef10855` | `1f4175413bf` |  |
| [resolve-path-full](resolve-path-full/summary.md) | 2026-11-21 | `9da2c0a98d8` | `63acef10855` | `1f4175413bf` |  |
