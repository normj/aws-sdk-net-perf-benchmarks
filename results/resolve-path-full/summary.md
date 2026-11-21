### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `1f4175413bf0e9277918d368aeaecb0902ef7f0a`
- Filter: `*PipelineBenchmarks.RestUrl_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3f5092230dd561332f867e9a978a4fe4688cc3ab`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 8/8 rows faster, 8/8 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net10.0 | 541.45 ns | 365.87 ns | 0.68 | faster | 1.18 KB | 584 B | 0.48 | less |
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net11.0 | 439.89 ns | 314.96 ns | 0.72 | faster | 1.18 KB | 584 B | 0.48 | less |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net10.0 | 721.61 ns | 445.18 ns | 0.62 | faster | 1.20 KB | 496 B | 0.41 | less |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net11.0 | 603.15 ns | 341.03 ns | 0.57 | faster | 1.20 KB | 496 B | 0.41 | less |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net10.0 | 293.66 ns | 159.52 ns | 0.54 | faster | 736 B | 112 B | 0.15 | less |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net11.0 | 269.86 ns | 161.00 ns | 0.60 | faster | 736 B | 112 B | 0.15 | less |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net10.0 | 399.58 ns | 157.83 ns | 0.39 | faster | 824 B | 96 B | 0.12 | less |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net11.0 | 385.38 ns | 154.73 ns | 0.40 | faster | 824 B | 96 B | 0.12 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net10.0 | base | 541.45 ns / 1.18 KB | 564.17 ns / 1.18 KB | 537.23 ns / 1.18 KB |
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net10.0 | pr | 364.90 ns / 584 B | 375.41 ns / 584 B | 365.87 ns / 584 B |
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net11.0 | base | 438.49 ns / 1.18 KB | 439.89 ns / 1.18 KB | 460.11 ns / 1.18 KB |
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net11.0 | pr | 314.40 ns / 584 B | 314.96 ns / 584 B | 315.43 ns / 584 B |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net10.0 | base | 721.61 ns / 1.20 KB | 744.30 ns / 1.20 KB | 719.39 ns / 1.20 KB |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net10.0 | pr | 445.18 ns / 496 B | 447.11 ns / 496 B | 442.96 ns / 496 B |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net11.0 | base | 608.24 ns / 1.20 KB | 603.15 ns / 1.20 KB | 599.06 ns / 1.20 KB |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net11.0 | pr | 341.03 ns / 496 B | 362.05 ns / 496 B | 340.87 ns / 496 B |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net10.0 | base | 304.22 ns / 736 B | 293.66 ns / 736 B | 291.88 ns / 736 B |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net10.0 | pr | 158.36 ns / 112 B | 159.52 ns / 112 B | 162.14 ns / 112 B |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net11.0 | base | 269.36 ns / 736 B | 269.86 ns / 736 B | 270.40 ns / 736 B |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net11.0 | pr | 158.57 ns / 112 B | 162.10 ns / 112 B | 161.00 ns / 112 B |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net10.0 | base | 399.58 ns / 824 B | 405.45 ns / 824 B | 394.24 ns / 824 B |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net10.0 | pr | 158.52 ns / 96 B | 157.83 ns / 96 B | 155.93 ns / 96 B |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net11.0 | base | 372.20 ns / 824 B | 388.79 ns / 824 B | 385.38 ns / 824 B |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net11.0 | pr | 154.30 ns / 96 B | 154.73 ns / 96 B | 157.44 ns / 96 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.01 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
