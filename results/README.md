# Benchmarks for normj/aws-sdk-net#48

PR: [perf(core): create DefaultRequest sub-resource, path-resource and trailing-header dictionaries on first use](https://github.com/normj/aws-sdk-net/pull/48)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [lazy-resource-maps-screen](lazy-resource-maps-screen/summary.md) | 2026-11-21 | `a32318aec8a` | `63acef10855` | `12630391dbc` | screens 1-2 NOT PROMISING on time noise only (alloc -240 B on every row); narrow 3-round screen 3 PROMISING; full run win |
| [lazy-resource-maps-screen2](lazy-resource-maps-screen2/summary.md) | 2026-11-21 | `a32318aec8a` | `63acef10855` | `12630391dbc` | screens 1-2 NOT PROMISING on time noise only (alloc -240 B on every row); narrow 3-round screen 3 PROMISING; full run win |
| [lazy-resource-maps-screen3](lazy-resource-maps-screen3/summary.md) | 2026-11-21 | `a32318aec8a` | `63acef10855` | `12630391dbc` | screens 1-2 NOT PROMISING on time noise only (alloc -240 B on every row); narrow 3-round screen 3 PROMISING; full run win |
| [lazy-resource-maps-full](lazy-resource-maps-full/summary.md) | 2026-11-21 | `a32318aec8a` | `63acef10855` | `12630391dbc` | screens 1-2 NOT PROMISING on time noise only (alloc -240 B on every row); narrow 3-round screen 3 PROMISING; full run win |
