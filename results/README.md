# Benchmarks for normj/aws-sdk-net#47

PR: [perf(core): cache Fn.ParseArn results by ARN text and return copies](https://github.com/normj/aws-sdk-net/pull/47)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [arn-cache-screen](arn-cache-screen/summary.md) | 2026-11-21 | `3d6237f389c` | `63acef10855` | `3faff12714d` |  |
| [arn-cache-full](arn-cache-full/summary.md) | 2026-11-21 | `3d6237f389c` | `63acef10855` | `3faff12714d` |  |
