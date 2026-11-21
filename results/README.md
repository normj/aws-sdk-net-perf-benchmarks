# Benchmarks for normj/aws-sdk-net#42

PR: [perf(core): grow the request header dictionary once before the retry and signing headers are added (.NET 8+)](https://github.com/normj/aws-sdk-net/pull/42)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [headers-ensure-capacity-screen](headers-ensure-capacity-screen/summary.md) | 2026-11-21 | `806d8ecd593` | `63acef10855` | `80e379872e1` | headers-ensure-capacity-* are this PR; request-headers-capacity-* are the dropped constructor-capacity variant (f9d95cbf), kept for comparison |
| [headers-ensure-capacity-full](headers-ensure-capacity-full/summary.md) | 2026-11-21 | `806d8ecd593` | `63acef10855` | `80e379872e1` | headers-ensure-capacity-* are this PR; request-headers-capacity-* are the dropped constructor-capacity variant (f9d95cbf), kept for comparison |
| [request-headers-capacity-screen](request-headers-capacity-screen/summary.md) | 2026-11-21 | `806d8ecd593` | `63acef10855` | `f9d95cbfe26` | headers-ensure-capacity-* are this PR; request-headers-capacity-* are the dropped constructor-capacity variant (f9d95cbf), kept for comparison |
| [request-headers-capacity-full](request-headers-capacity-full/summary.md) | 2026-11-21 | `806d8ecd593` | `63acef10855` | `f9d95cbfe26` | headers-ensure-capacity-* are this PR; request-headers-capacity-* are the dropped constructor-capacity variant (f9d95cbf), kept for comparison |
| [request-headers-capacity-preinvoke-screen](request-headers-capacity-preinvoke-screen/summary.md) | 2026-11-21 | `806d8ecd593` | `63acef10855` | `f9d95cbfe26` | headers-ensure-capacity-* are this PR; request-headers-capacity-* are the dropped constructor-capacity variant (f9d95cbf), kept for comparison |
