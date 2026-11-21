# Benchmarks for normj/aws-sdk-net#39

PR: [perf(core): find XML escape characters with SearchValues in XMLEncodedBufferTextWriter on .NET 8+](https://github.com/normj/aws-sdk-net/pull/39)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [xml-writer-indexofany-screen](xml-writer-indexofany-screen/summary.md) | 2026-11-21 | `3584152a0b8` | `63acef10855` | `d734d67b18e` |  |
| [xml-writer-indexofany-full](xml-writer-indexofany-full/summary.md) | 2026-11-21 | `3584152a0b8` | `63acef10855` | `d734d67b18e` |  |
