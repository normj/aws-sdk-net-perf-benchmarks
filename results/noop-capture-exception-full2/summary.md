### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f3e69d694f84673bc4a3a2a0289d8f429de3350f`
- Filter: `*PipelineBenchmarks.*Error*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@5f0bd7f0bebbca0d4f383128b0edbd53b6ad916c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 4/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 277.48 us | 119.88 us | 0.43 | faster | 108.47 KB | 44.60 KB | 0.41 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 222.30 us | 99.12 us | 0.45 | faster | 108.52 KB | 44.67 KB | 0.41 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 56.47 us | 39.14 us | 0.69 | faster | 44.28 KB | 15.14 KB | 0.34 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 53.71 us | 33.64 us | 0.63 | faster | 48.31 KB | 15.14 KB | 0.31 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 314.46 us / 108.47 KB | 277.48 us / 108.43 KB | 251.51 us / 108.51 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 119.88 us / 44.60 KB | 119.86 us / 44.60 KB | 140.77 us / 44.60 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 237.46 us / 108.53 KB | 222.30 us / 108.52 KB | 220.49 us / 108.51 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 99.12 us / 44.67 KB | 98.16 us / 44.67 KB | 120.69 us / 44.67 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 59.09 us / 44.28 KB | 56.47 us / 44.28 KB | 56.43 us / 44.28 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 39.34 us / 15.14 KB | 38.73 us / 15.14 KB | 39.14 us / 15.14 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 51.27 us / 44.28 KB | 53.71 us / 48.31 KB | 54.31 us / 48.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 33.64 us / 15.14 KB | 33.47 us / 15.14 KB | 36.21 us / 15.14 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
