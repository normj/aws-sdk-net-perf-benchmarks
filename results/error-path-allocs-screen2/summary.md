### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `892b9f453e3eee6a8334a72ae341f31de0faf201`
- Filter: `*PipelineBenchmarks.*Error*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@2035ceb1abcc5e764d9041f90bdd68213ab43614`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeSync_ServiceError alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 264.62 us | 275.65 us | 1.04 | same | 108.47 KB | 108.01 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 58.38 us | 56.77 us | 0.97 | same | 44.31 KB | 43.67 KB | 0.99 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 277.23 us / 108.47 KB | 252.02 us / 108.46 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 249.41 us / 107.99 KB | 301.89 us / 108.02 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 59.85 us / 44.31 KB | 56.92 us / 44.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 56.39 us / 43.67 KB | 57.15 us / 43.67 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
