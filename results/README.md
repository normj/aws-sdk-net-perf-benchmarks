# Benchmarks for normj/aws-sdk-net#13

PR: [perf(core): build the JSON error response body string once in JsonErrorResponseUnmarshaller](https://github.com/normj/aws-sdk-net/pull/13)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [json-error-body-once-screen](json-error-body-once-screen/summary.md) | 2026-11-21 | `4fb8f8a526c` | `63acef10855` | `40433098199` |  |
| [json-error-body-once-full](json-error-body-once-full/summary.md) | 2026-11-21 | `4fb8f8a526c` | `63acef10855` | `40433098199` |  |
