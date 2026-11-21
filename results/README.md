# Benchmarks for normj/aws-sdk-net#15

PR: [perf(core): back UserAgentDetails with lazily created lists instead of hash sets](https://github.com/normj/aws-sdk-net/pull/15)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [ua-details-lists-screen](ua-details-lists-screen/summary.md) | 2026-11-21 | `29d065df261` | `63acef10855` | `cc07ddc1085` |  |
| [ua-details-lists-full](ua-details-lists-full/summary.md) | 2026-11-21 | `29d065df261` | `63acef10855` | `cc07ddc1085` |  |
