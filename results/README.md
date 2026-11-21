# Benchmarks for normj/aws-sdk-net#60

PR: [perf(core): reuse the previous request's endpoint URL and parsed Uri in BaseEndpointResolver](https://github.com/normj/aws-sdk-net/pull/60)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [endpoint-uri-reuse-screen](endpoint-uri-reuse-screen/summary.md) | 2026-11-21 | `eb39abde891` | `63acef10855` | `d06f331686c` |  |
| [endpoint-uri-reuse-full](endpoint-uri-reuse-full/summary.md) | 2026-11-21 | `eb39abde891` | `63acef10855` | `d06f331686c` |  |
