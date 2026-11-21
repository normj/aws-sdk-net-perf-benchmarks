# Benchmarks for normj/aws-sdk-net#49

PR: [perf(core): create XmlUnmarshallerContext's StreamReader when the XML is first read](https://github.com/normj/aws-sdk-net/pull/49)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [xml-lazy-streamreader-screen](xml-lazy-streamreader-screen/summary.md) | 2026-11-21 | `766014b8720` | `63acef10855` | `bb97473ffb0` |  |
| [xml-lazy-streamreader-full](xml-lazy-streamreader-full/summary.md) | 2026-11-21 | `766014b8720` | `63acef10855` | `bb97473ffb0` |  |
