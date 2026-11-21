# Benchmarks for normj/aws-sdk-net#17

PR: [perf(core): interpolate endpoint JSON templates without building a JsonDocument](https://github.com/normj/aws-sdk-net/pull/17)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [interpolatejson-reader-screen](interpolatejson-reader-screen/summary.md) | 2026-11-21 | `e47dc856a18` | `63acef10855` | `801e615cfcd` | Measured at 801e615; the PR head adds only the DevConfig |
| [interpolatejson-reader-b2-screen](interpolatejson-reader-b2-screen/summary.md) | 2026-11-21 | `e47dc856a18` | `63acef10855` | `801e615cfcd` | Measured at 801e615; the PR head adds only the DevConfig |
| [interpolatejson-reader-full](interpolatejson-reader-full/summary.md) | 2026-11-21 | `e47dc856a18` | `63acef10855` | `801e615cfcd` | Measured at 801e615; the PR head adds only the DevConfig |
| [interpolatejson-reader-json-full](interpolatejson-reader-json-full/summary.md) | 2026-11-21 | `e47dc856a18` | `63acef10855` | `801e615cfcd` | Measured at 801e615; the PR head adds only the DevConfig |
