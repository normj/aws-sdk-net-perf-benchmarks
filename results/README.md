# Benchmarks for normj/aws-sdk-net#51

PR: [perf(core): create AmazonWebServiceRequest's user agent details and event lock on first use](https://github.com/normj/aws-sdk-net/pull/51)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [request-object-lazy-screen](request-object-lazy-screen/summary.md) | 2026-11-21 | `bdbd582feba` | `63acef10855` | `9ebeb7ceb3e` |  |
| [request-object-lazy-full](request-object-lazy-full/summary.md) | 2026-11-21 | `bdbd582feba` | `63acef10855` | `9ebeb7ceb3e` |  |
