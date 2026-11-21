# Benchmarks for normj/aws-sdk-net#53

PR: [perf(core): keep XML element attributes in reused arrays in XmlUnmarshallerContext](https://github.com/normj/aws-sdk-net/pull/53)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [xml-attribute-arrays-screen](xml-attribute-arrays-screen/summary.md) | 2026-11-21 | `8f38303209b` | `63acef10855` | `c96f06806de` |  |
| [xml-attribute-arrays-full](xml-attribute-arrays-full/summary.md) | 2026-11-21 | `8f38303209b` | `63acef10855` | `c96f06806de` |  |
