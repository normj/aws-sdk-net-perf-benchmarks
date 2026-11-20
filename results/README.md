# Benchmarks for normj/aws-sdk-net#9

PR: [perf(core): parse strict ISO 8601 UTC timestamps without DateTime.Parse in DateTimeUnmarshaller](https://github.com/normj/aws-sdk-net/pull/9)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [iso8601-parse-screen](iso8601-parse-screen/summary.md) | 2026-11-20 | `cfb2431b0b3` | `63acef10855` | `4cd86d7b75c` |  |
| [iso8601-parse-full](iso8601-parse-full/summary.md) | 2026-11-20 | `cfb2431b0b3` | `63acef10855` | `4cd86d7b75c` |  |
| [iso8601-parse-e2e-full](iso8601-parse-e2e-full/summary.md) | 2026-11-20 | `cfb2431b0b3` | `63acef10855` | `4cd86d7b75c` |  |
