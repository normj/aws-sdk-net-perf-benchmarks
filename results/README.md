# Benchmarks for normj/aws-sdk-net#56

PR: [perf(core): size XmlUnmarshallerContext's StreamReader buffer to small response bodies](https://github.com/normj/aws-sdk-net/pull/56)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [xml-streamreader-size-screen](xml-streamreader-size-screen/summary.md) | 2026-11-21 | `1c657695010` | `63acef10855` | `bfbb8bcafdc` |  |
| [xml-streamreader-size-full](xml-streamreader-size-full/summary.md) | 2026-11-21 | `1c657695010` | `63acef10855` | `bfbb8bcafdc` |  |
