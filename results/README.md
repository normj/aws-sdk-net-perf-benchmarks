# Benchmarks for normj/aws-sdk-net#8

PR: [perf(core): reuse sanitized User-Agent components between requests in the Marshaller handler](https://github.com/normj/aws-sdk-net/pull/8)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [ua-components-screen](ua-components-screen/summary.md) | 2026-11-20 | `b496276f584` | `63acef10855` | `7497b8c489a` |  |
| [ua-components-full](ua-components-full/summary.md) | 2026-11-20 | `b496276f584` | `63acef10855` | `7497b8c489a` |  |
