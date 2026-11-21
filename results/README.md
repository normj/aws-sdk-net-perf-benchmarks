# Benchmarks for normj/aws-sdk-net#30

PR: [perf(core): use Convert.ToHexStringLower for lowercase AWSSDKUtils.ToHex on .NET 10+](https://github.com/normj/aws-sdk-net/pull/30)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [tohex-lower-screen](tohex-lower-screen/summary.md) | 2026-11-21 | `289a45a09f7` | `63acef10855` | `be31be44580` |  |
| [tohex-lower-screen2](tohex-lower-screen2/summary.md) | 2026-11-21 | `289a45a09f7` | `63acef10855` | `67217f87036` |  |
| [tohex-lower-full](tohex-lower-full/summary.md) | 2026-11-21 | `289a45a09f7` | `63acef10855` | `67217f87036` |  |
