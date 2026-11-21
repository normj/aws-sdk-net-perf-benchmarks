# Benchmarks for normj/aws-sdk-net#55

PR: [perf(core): read endpoint auth schemes without LINQ in BaseAuthResolverHandler](https://github.com/normj/aws-sdk-net/pull/55)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [endpoint-auth-schemes-screen](endpoint-auth-schemes-screen/summary.md) | 2026-11-21 | `5e552161ac2` | `63acef10855` | `d1382bebc6b` |  |
| [endpoint-auth-schemes-full](endpoint-auth-schemes-full/summary.md) | 2026-11-21 | `5e552161ac2` | `63acef10855` | `d1382bebc6b` |  |
