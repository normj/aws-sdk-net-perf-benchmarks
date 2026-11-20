# Benchmarks for normj/aws-sdk-net#5

PR: [perf(core): validate endpoint host labels and S3 bucket names without string.Split](https://github.com/normj/aws-sdk-net/pull/5)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [hostlabel-no-split-screen](hostlabel-no-split-screen/summary.md) | 2026-11-20 | `3280783766c` | `63acef10855` | `8be2ab2a1fb` |  |
| [hostlabel-no-split-full](hostlabel-no-split-full/summary.md) | 2026-11-20 | `3280783766c` | `63acef10855` | `8be2ab2a1fb` |  |
