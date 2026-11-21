# Benchmarks for normj/aws-sdk-net#50

PR: [perf(core): split InterpolateJson templates once and interpolate only placeholder strings](https://github.com/normj/aws-sdk-net/pull/50)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [interpolatejson-plan-screen](interpolatejson-plan-screen/summary.md) | 2026-11-21 | `e8787bdc937` | `63acef10855` | `f18d3c25644` |  |
| [interpolatejson-plan-full](interpolatejson-plan-full/summary.md) | 2026-11-21 | `e8787bdc937` | `63acef10855` | `f18d3c25644` |  |
| [interpolatejson-plan-resolve-full](interpolatejson-plan-resolve-full/summary.md) | 2026-11-21 | `e8787bdc937` | `63acef10855` | `f18d3c25644` |  |
| [interpolatejson-plan-v2-vs-base](interpolatejson-plan-v2-vs-base/summary.md) | 2026-11-21 | `66aa9098f61` | `63acef10855` | `66aa9098f61` | after security review fix 66aa909 |
| [interpolatejson-plan-v2-vs-prev](interpolatejson-plan-v2-vs-prev/summary.md) | 2026-11-21 | `66aa9098f61` | `e8787bdc937` | `66aa9098f61` | after security review fix 66aa909 |
| [interpolatejson-plan-v2-resolve-vs-base](interpolatejson-plan-v2-resolve-vs-base/summary.md) | 2026-11-21 | `66aa9098f61` | `63acef10855` | `66aa9098f61` | after security review fix 66aa909 |
