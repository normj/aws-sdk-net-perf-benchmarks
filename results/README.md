# Benchmarks for normj/aws-sdk-net#29

PR: [perf(core): hash SigV4 request bodies into a stack buffer with the per-thread SHA-256 instance on .NET 10+](https://github.com/normj/aws-sdk-net/pull/29)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [payload-hash-screen](payload-hash-screen/summary.md) | 2026-11-21 | `3992a6949a5` | `63acef10855` | `e5066d062d6` | screen = first variant (one-shot SHA256.HashData), NOT PROMISING; screen2..4 and full = this PR |
| [payload-hash-screen2](payload-hash-screen2/summary.md) | 2026-11-21 | `3992a6949a5` | `63acef10855` | `25020562a16` | screen = first variant (one-shot SHA256.HashData), NOT PROMISING; screen2..4 and full = this PR |
| [payload-hash-screen3](payload-hash-screen3/summary.md) | 2026-11-21 | `3992a6949a5` | `63acef10855` | `9916a56133d` | screen = first variant (one-shot SHA256.HashData), NOT PROMISING; screen2..4 and full = this PR |
| [payload-hash-screen4](payload-hash-screen4/summary.md) | 2026-11-21 | `3992a6949a5` | `63acef10855` | `9916a56133d` | screen = first variant (one-shot SHA256.HashData), NOT PROMISING; screen2..4 and full = this PR |
| [payload-hash-full](payload-hash-full/summary.md) | 2026-11-21 | `3992a6949a5` | `63acef10855` | `9916a56133d` | screen = first variant (one-shot SHA256.HashData), NOT PROMISING; screen2..4 and full = this PR |
