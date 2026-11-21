# Benchmarks for normj/aws-sdk-net#31

PR: [perf(core): create DefaultRequest parameter collections on first use and skip unused before-request event args](https://github.com/normj/aws-sdk-net/pull/31)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [lazy-request-parameters-screen](lazy-request-parameters-screen/summary.md) | 2026-11-21 | `9590fa88666` | `63acef10855` | `9590fa88666` |  |
| [lazy-request-parameters-screen2](lazy-request-parameters-screen2/summary.md) | 2026-11-21 | `9590fa88666` | `63acef10855` | `9590fa88666` |  |
| [lazy-request-parameters-screen3](lazy-request-parameters-screen3/summary.md) | 2026-11-21 | `9590fa88666` | `63acef10855` | `9590fa88666` |  |
| [lazy-request-parameters-full](lazy-request-parameters-full/summary.md) | 2026-11-21 | `9590fa88666` | `63acef10855` | `9590fa88666` |  |
