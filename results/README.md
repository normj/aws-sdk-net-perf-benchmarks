# Benchmarks for normj/aws-sdk-net#41

PR: [perf(core): size the copied response header dictionary to the response's header count on .NET 8+](https://github.com/normj/aws-sdk-net/pull/41)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [response-headers-capacity-screen](response-headers-capacity-screen/summary.md) | 2026-11-21 | `d69f2e6b311` | `63acef10855` | `800f48b75bf` |  |
| [response-headers-capacity-full](response-headers-capacity-full/summary.md) | 2026-11-21 | `d69f2e6b311` | `63acef10855` | `800f48b75bf` |  |
