# Benchmarks for normj/aws-sdk-net#58

PR: [perf(core): read cached or synchronous credentials without a task in the async signer and endpoint discovery handler](https://github.com/normj/aws-sdk-net/pull/58)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [sync-cached-credentials-screen](sync-cached-credentials-screen/summary.md) | 2026-11-21 | `0f18bfd2216` | `63acef10855` | `47367393636` |  |
| [sync-cached-credentials-screen2](sync-cached-credentials-screen2/summary.md) | 2026-11-21 | `0f18bfd2216` | `63acef10855` | `47367393636` |  |
| [sync-cached-credentials-full](sync-cached-credentials-full/summary.md) | 2026-11-21 | `0f18bfd2216` | `63acef10855` | `c0d6b50ae6b` |  |
