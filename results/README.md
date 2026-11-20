# Benchmarks for normj/aws-sdk-net#12

PR: [perf(core): serve cached default-chain credentials without a timeout source or nested async calls](https://github.com/normj/aws-sdk-net/pull/12)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [cached-identity-fast-path-screen](cached-identity-fast-path-screen/summary.md) | 2026-11-20 | `c1734e8a858` | `63acef10855` | `7a948a285bd` |  |
| [cached-identity-fast-path-full](cached-identity-fast-path-full/summary.md) | 2026-11-20 | `c1734e8a858` | `63acef10855` | `7a948a285bd` |  |
