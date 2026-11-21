### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `80e379872e1e498f7cfa976aa82dd0ba04f4a331`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e476b0db37ef8af19ea2212b80411fb387a51e5f`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.4 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/14 rows faster, 12/14 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.43 us | 15.43 us | 1.00 | same | 11.77 KB | 11.37 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.05 us | 14.49 us | 1.03 | same | 11.77 KB | 11.36 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 26.42 us | 26.59 us | 1.01 | same | 14.72 KB | 14.31 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 21.30 us | 22.13 us | 1.04 | same | 13.70 KB | 13.29 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 23.65 us | 23.13 us | 0.98 | same | 13.04 KB | 12.63 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.42 us | 19.49 us | 1.00 | same | 11.92 KB | 11.52 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 287.50 us | 258.72 us | 0.90 | same | 108.47 KB | 108.05 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 227.50 us | 225.90 us | 0.99 | same | 108.57 KB | 108.08 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.16 us | 12.96 us | 0.98 | same | 10.51 KB | 10.10 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.22 us | 12.40 us | 1.02 | same | 10.51 KB | 10.10 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.16 us | 15.03 us | 0.99 | same | 12.19 KB | 11.78 KB | 0.97 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 13.75 us | 14.00 us | 1.02 | same | 12.19 KB | 11.78 KB | 0.97 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 57.76 us | 58.13 us | 1.01 | same | 44.31 KB | 43.83 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 50.96 us | 51.95 us | 1.02 | same | 44.30 KB | 43.83 KB | 0.99 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.25 us / 11.77 KB | 15.43 us / 11.77 KB | 15.57 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.54 us / 11.37 KB | 15.34 us / 11.37 KB | 15.43 us / 11.37 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.01 us / 11.77 KB | 14.05 us / 11.77 KB | 14.79 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 20.28 us / 11.36 KB | 14.49 us / 11.36 KB | 14.44 us / 11.36 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 24.65 us / 14.72 KB | 26.42 us / 14.72 KB | 27.21 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 31.73 us / 14.31 KB | 26.17 us / 14.31 KB | 26.59 us / 14.31 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 20.61 us / 13.66 KB | 21.30 us / 13.70 KB | 23.06 us / 13.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 21.94 us / 13.39 KB | 22.40 us / 13.26 KB | 22.13 us / 13.29 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 21.06 us / 13.04 KB | 23.65 us / 13.04 KB | 23.98 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 24.72 us / 12.63 KB | 21.84 us / 12.63 KB | 23.13 us / 12.63 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 18.77 us / 11.91 KB | 19.42 us / 11.92 KB | 20.39 us / 12.01 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 20.13 us / 11.60 KB | 19.44 us / 11.51 KB | 19.49 us / 11.52 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 306.34 us / 108.49 KB | 287.50 us / 108.47 KB | 259.37 us / 108.46 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 288.22 us / 108.08 KB | 252.43 us / 108.05 KB | 258.72 us / 108.01 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 225.98 us / 108.57 KB | 227.50 us / 108.57 KB | 231.03 us / 108.57 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 225.48 us / 108.08 KB | 225.90 us / 108.09 KB | 233.07 us / 108.08 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.01 us / 10.51 KB | 13.16 us / 10.51 KB | 13.26 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.18 us / 10.10 KB | 12.80 us / 10.10 KB | 12.96 us / 10.10 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.22 us / 10.51 KB | 11.93 us / 10.51 KB | 12.55 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 18.00 us / 10.10 KB | 12.23 us / 10.10 KB | 12.40 us / 10.10 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 14.95 us / 12.19 KB | 15.16 us / 12.19 KB | 15.29 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 15.32 us / 11.78 KB | 14.78 us / 11.78 KB | 15.03 us / 11.78 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 13.75 us / 12.19 KB | 13.37 us / 12.19 KB | 14.30 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 14.19 us / 11.78 KB | 13.92 us / 11.78 KB | 14.00 us / 11.78 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 57.54 us / 44.31 KB | 58.75 us / 44.31 KB | 57.76 us / 44.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 59.03 us / 43.83 KB | 57.61 us / 43.83 KB | 58.13 us / 43.83 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 50.81 us / 44.30 KB | 50.96 us / 44.30 KB | 52.21 us / 44.30 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 51.40 us / 43.83 KB | 52.29 us / 43.83 KB | 51.95 us / 43.83 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.55 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.56 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
