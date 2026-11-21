### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `862cb393ed10461a63d5d8c08fedc5fa769f7382`
- Filter: `*PipelineBenchmarks.*Error*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeAsync_ServiceError_Yielding time, PipelineBenchmarks.InvokeAsync_ServiceError_Yielding alloc, PipelineBenchmarks.InvokeSync_ServiceError time, PipelineBenchmarks.InvokeSync_ServiceError alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 287.79 us | 120.54 us | 0.42 | faster | 108.71 KB | 44.60 KB | 0.41 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 56.91 us | 38.82 us | 0.68 | faster | 44.53 KB | 15.14 KB | 0.34 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 287.79 us / 108.71 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 120.54 us / 44.60 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 56.91 us / 44.53 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 38.82 us / 15.14 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
