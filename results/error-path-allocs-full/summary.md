### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `892b9f453e3eee6a8334a72ae341f31de0faf201`
- Filter: `*PipelineBenchmarks.*Error*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3c2f90419fc0f4eac2add461284ac4465322a13f`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/4 rows faster, 1/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 256.87 us | 265.04 us | 1.03 | same | 108.46 KB | 107.99 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 223.42 us | 234.65 us | 1.05 | same | 108.57 KB | 108.06 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 57.58 us | 56.37 us | 0.98 | same | 44.32 KB | 43.67 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 52.40 us | 50.51 us | 0.96 | same | 44.31 KB | 43.67 KB | 0.99 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 256.87 us / 108.46 KB | 262.94 us / 108.46 KB | 249.04 us / 108.49 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 267.12 us / 107.99 KB | 250.57 us / 107.99 KB | 265.04 us / 107.99 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 230.98 us / 108.57 KB | 219.08 us / 108.57 KB | 223.42 us / 108.57 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 234.65 us / 108.05 KB | 246.57 us / 108.06 KB | 223.77 us / 108.06 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 57.58 us / 44.32 KB | 56.79 us / 44.32 KB | 59.11 us / 44.32 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 61.23 us / 47.70 KB | 56.37 us / 43.67 KB | 55.44 us / 43.67 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 52.40 us / 44.31 KB | 50.93 us / 44.30 KB | 52.93 us / 48.05 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 50.51 us / 43.67 KB | 50.62 us / 43.67 KB | 50.48 us / 43.67 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.31 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
