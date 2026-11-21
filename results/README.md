# Benchmarks for normj/aws-sdk-net#18

PR: [perf(core): append SigV4 canonical query parameters without intermediate strings or copies](https://github.com/normj/aws-sdk-net/pull/18)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [query-params-screen](query-params-screen/summary.md) | 2026-11-21 | `4aa920f370c` | `63acef10855` | `0ce114a2c17` |  |
| [query-params-full](query-params-full/summary.md) | 2026-11-21 | `4aa920f370c` | `63acef10855` | `0ce114a2c17` |  |
| [query-params-full-unfiltered](query-params-full-unfiltered/summary.md) | 2026-11-21 | `4aa920f370c` | `63acef10855` | `0ce114a2c17` |  |
