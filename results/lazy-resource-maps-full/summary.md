### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `12630391dbc636760f89c2ceedb64ff1a6feaf8b`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@47588afb2a861a099dbfa1c270fbda311984485a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/14 rows faster, 11/14 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 16.73 us | 15.95 us | 0.95 | same | 11.77 KB | 11.54 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.90 us | 14.69 us | 0.99 | same | 11.77 KB | 11.53 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 30.01 us | 28.28 us | 0.94 | same | 14.72 KB | 14.48 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 24.12 us | 22.74 us | 0.94 | same | 13.76 KB | 13.60 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 26.77 us | 25.25 us | 0.94 | same | 13.04 KB | 12.80 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 20.77 us | 20.90 us | 1.01 | same | 12.10 KB | 11.80 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 280.89 us | 260.75 us | 0.93 | same | 108.47 KB | 108.21 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 248.15 us | 237.16 us | 0.96 | same | 108.58 KB | 108.34 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.91 us | 13.54 us | 0.97 | same | 10.51 KB | 10.27 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.84 us | 12.76 us | 0.99 | same | 10.51 KB | 10.27 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.72 us | 15.33 us | 0.97 | same | 12.19 KB | 11.95 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 14.54 us | 14.37 us | 0.99 | same | 12.19 KB | 11.95 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 62.92 us | 59.05 us | 0.94 | faster | 48.34 KB | 44.00 KB | 0.91 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 53.59 us | 55.98 us | 1.04 | same | 44.30 KB | 48.04 KB | 1.08 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 16.73 us / 11.77 KB | 17.06 us / 11.77 KB | 16.15 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 16.25 us / 11.54 KB | 15.60 us / 11.54 KB | 15.95 us / 11.54 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 20.75 us / 11.77 KB | 14.90 us / 11.77 KB | 14.79 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 20.46 us / 11.53 KB | 14.69 us / 11.53 KB | 14.48 us / 11.53 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 34.44 us / 14.72 KB | 30.01 us / 14.72 KB | 28.67 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 30.55 us / 14.48 KB | 28.27 us / 14.48 KB | 28.28 us / 14.48 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 24.13 us / 13.73 KB | 22.38 us / 13.76 KB | 24.12 us / 13.83 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 22.79 us / 13.57 KB | 22.74 us / 13.67 KB | 22.01 us / 13.60 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 27.70 us / 13.04 KB | 26.77 us / 13.04 KB | 24.86 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 26.62 us / 12.80 KB | 25.25 us / 12.80 KB | 23.73 us / 12.80 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 33.49 us / 12.74 KB | 20.64 us / 11.95 KB | 20.77 us / 12.10 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 28.91 us / 11.75 KB | 20.90 us / 11.80 KB | 20.72 us / 11.88 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 311.84 us / 108.49 KB | 280.89 us / 108.47 KB | 263.00 us / 108.47 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 296.62 us / 108.24 KB | 260.75 us / 108.21 KB | 258.79 us / 108.20 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 256.90 us / 108.58 KB | 239.31 us / 108.58 KB | 248.15 us / 108.56 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 248.24 us / 108.34 KB | 237.16 us / 108.34 KB | 232.48 us / 108.33 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.88 us / 10.51 KB | 13.96 us / 10.51 KB | 13.91 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 14.53 us / 10.27 KB | 13.41 us / 10.27 KB | 13.54 us / 10.27 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 16.35 us / 10.51 KB | 12.84 us / 10.51 KB | 12.65 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 13.44 us / 10.27 KB | 12.64 us / 10.27 KB | 12.76 us / 10.27 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 16.62 us / 12.19 KB | 15.63 us / 12.19 KB | 15.72 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 16.35 us / 11.95 KB | 15.25 us / 11.95 KB | 15.33 us / 11.95 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 14.74 us / 12.19 KB | 14.54 us / 12.19 KB | 14.27 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 14.52 us / 11.95 KB | 14.37 us / 11.95 KB | 14.37 us / 11.95 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 72.82 us / 48.34 KB | 62.47 us / 48.34 KB | 62.92 us / 48.34 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 61.49 us / 44.00 KB | 58.92 us / 44.00 KB | 59.05 us / 44.00 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 53.71 us / 44.31 KB | 53.59 us / 44.30 KB | 53.05 us / 44.30 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 57.48 us / 48.04 KB | 53.68 us / 44.00 KB | 55.98 us / 48.04 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.46 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
