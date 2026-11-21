# Benchmarks for normj/aws-sdk-net#23

PR: [perf(core): return JSON true/false tokens directly in BoolUnmarshaller and NullableBoolUnmarshaller](https://github.com/normj/aws-sdk-net/pull/23)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [json-bool-token-screen](json-bool-token-screen/summary.md) | 2026-11-21 | `18d44a100ee` | `63acef10855` | `9498ead90a5` |  |
| [json-bool-token-full](json-bool-token-full/summary.md) | 2026-11-21 | `18d44a100ee` | `63acef10855` | `9498ead90a5` |  |
