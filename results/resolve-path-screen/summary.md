### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `1f4175413bf0e9277918d368aeaecb0902ef7f0a`
- Filter: `*PipelineBenchmarks.RestUrl_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3f5092230dd561332f867e9a978a4fe4688cc3ab`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.RestUrl_ComposeUrl_Label time, PipelineBenchmarks.RestUrl_ComposeUrl_Label alloc, PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey time, PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey alloc, PipelineBenchmarks.RestUrl_ResolvePath_Label time, PipelineBenchmarks.RestUrl_ResolvePath_Label alloc, PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey time, PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net10.0 | 570.52 ns | 388.54 ns | 0.68 | faster | 1.18 KB | 584 B | 0.48 | less |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net10.0 | 767.14 ns | 474.69 ns | 0.62 | faster | 1.20 KB | 496 B | 0.41 | less |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net10.0 | 315.04 ns | 163.73 ns | 0.52 | faster | 736 B | 112 B | 0.15 | less |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net10.0 | 426.15 ns | 160.89 ns | 0.38 | faster | 824 B | 96 B | 0.12 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net10.0 | base | 556.12 ns / 1.18 KB | 584.92 ns / 1.18 KB |
| PipelineBenchmarks.RestUrl_ComposeUrl_Label | net10.0 | pr | 384.26 ns / 584 B | 392.83 ns / 584 B |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net10.0 | base | 736.17 ns / 1.20 KB | 798.12 ns / 1.20 KB |
| PipelineBenchmarks.RestUrl_ComposeUrl_S3GreedyKey | net10.0 | pr | 479.16 ns / 496 B | 470.23 ns / 496 B |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net10.0 | base | 303.77 ns / 736 B | 326.32 ns / 736 B |
| PipelineBenchmarks.RestUrl_ResolvePath_Label | net10.0 | pr | 161.93 ns / 112 B | 165.53 ns / 112 B |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net10.0 | base | 412.03 ns / 824 B | 440.28 ns / 824 B |
| PipelineBenchmarks.RestUrl_ResolvePath_S3GreedyKey | net10.0 | pr | 159.08 ns / 96 B | 162.69 ns / 96 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
