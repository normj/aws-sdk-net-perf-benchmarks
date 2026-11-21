# Benchmarks for normj/aws-sdk-net#33

PR: [perf(core): create RequestMetrics' lock and error list on first use](https://github.com/normj/aws-sdk-net/pull/33)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [request-metrics-lazy-screen](request-metrics-lazy-screen/summary.md) | 2026-11-21 | `aca6cc99898` | `63acef10855` | `65a0d1bdc13` | screen 1 NOT PROMISING on 1-round time noise only; screen 2 PROMISING; full run win |
| [request-metrics-lazy-screen2](request-metrics-lazy-screen2/summary.md) | 2026-11-21 | `aca6cc99898` | `63acef10855` | `65a0d1bdc13` | screen 1 NOT PROMISING on 1-round time noise only; screen 2 PROMISING; full run win |
| [request-metrics-lazy-full](request-metrics-lazy-full/summary.md) | 2026-11-21 | `aca6cc99898` | `63acef10855` | `65a0d1bdc13` | screen 1 NOT PROMISING on 1-round time noise only; screen 2 PROMISING; full run win |
