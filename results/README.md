# Benchmarks for normj/aws-sdk-net#32

PR: [perf(core): look up endpoint partitions without a reader-writer lock](https://github.com/normj/aws-sdk-net/pull/32)

Each directory is one ab.sh run: `summary.md` is the table posted in the PR, `meta.json` has the
exact aws-sdk-net SHAs and options, and `bench-src/` is the benchmark source that was measured.

| Run | Recorded | PR head when recorded | Base | Measured PR commit | Note |
|---|---|---|---|---|---|
| [partition-snapshot-screen](partition-snapshot-screen/summary.md) | 2026-11-21 | `ef76dbbc6f3` | `63acef10855` | `0a4dca0d0b9` |  |
| [partition-snapshot-full](partition-snapshot-full/summary.md) | 2026-11-21 | `ef76dbbc6f3` | `63acef10855` | `0a4dca0d0b9` |  |
