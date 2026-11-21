### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f9d95cbfe2617bfd4972e7f376d86e06f87963aa`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e476b0db37ef8af19ea2212b80411fb387a51e5f`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/14 rows faster, 10/14 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.38 us | 14.88 us | 0.97 | same | 11.77 KB | 11.40 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.18 us | 13.87 us | 0.98 | same | 11.77 KB | 11.39 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 25.75 us | 25.02 us | 0.97 | same | 14.72 KB | 14.34 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 21.02 us | 21.36 us | 1.02 | same | 13.69 KB | 13.43 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 21.57 us | 21.32 us | 0.99 | same | 13.04 KB | 12.66 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.00 us | 20.62 us | 1.09 | same | 11.91 KB | 11.59 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 250.24 us | 254.04 us | 1.02 | same | 108.46 KB | 108.04 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 226.80 us | 225.59 us | 0.99 | same | 108.57 KB | 108.15 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.10 us | 12.83 us | 0.98 | same | 10.51 KB | 10.13 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.12 us | 12.02 us | 0.99 | same | 10.51 KB | 10.13 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 14.87 us | 14.57 us | 0.98 | same | 12.19 KB | 11.81 KB | 0.97 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 13.64 us | 13.56 us | 0.99 | same | 12.19 KB | 11.81 KB | 0.97 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 57.29 us | 56.83 us | 0.99 | same | 44.32 KB | 43.87 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 51.31 us | 50.69 us | 0.99 | same | 44.30 KB | 43.87 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.13 us / 11.77 KB | 15.38 us / 11.77 KB | 15.39 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.33 us / 11.40 KB | 14.88 us / 11.40 KB | 14.77 us / 11.40 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.30 us / 11.77 KB | 14.09 us / 11.77 KB | 14.18 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 13.77 us / 11.39 KB | 14.10 us / 11.39 KB | 13.87 us / 11.39 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 25.75 us / 14.72 KB | 24.44 us / 14.72 KB | 26.46 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 25.49 us / 14.34 KB | 25.02 us / 14.34 KB | 24.89 us / 14.34 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 21.00 us / 13.66 KB | 21.47 us / 13.69 KB | 21.02 us / 13.70 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 21.36 us / 13.43 KB | 21.91 us / 13.58 KB | 20.91 us / 13.31 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 22.97 us / 13.04 KB | 21.57 us / 13.04 KB | 21.29 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 22.05 us / 12.66 KB | 21.32 us / 12.66 KB | 20.42 us / 12.66 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 21.55 us / 11.91 KB | 18.83 us / 11.92 KB | 19.00 us / 11.91 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 20.62 us / 11.59 KB | 21.97 us / 11.70 KB | 19.32 us / 11.55 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 253.77 us / 108.49 KB | 249.39 us / 108.46 KB | 250.24 us / 108.46 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 264.60 us / 108.04 KB | 254.04 us / 108.04 KB | 253.53 us / 108.04 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 224.06 us / 108.57 KB | 226.80 us / 108.57 KB | 230.08 us / 108.57 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 225.59 us / 108.15 KB | 220.62 us / 108.15 KB | 232.61 us / 108.17 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.10 us / 10.51 KB | 13.02 us / 10.51 KB | 13.38 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.04 us / 10.13 KB | 12.83 us / 10.13 KB | 12.68 us / 10.13 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 11.96 us / 10.51 KB | 12.13 us / 10.51 KB | 12.12 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 12.07 us / 10.13 KB | 12.01 us / 10.13 KB | 12.02 us / 10.13 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 14.87 us / 12.19 KB | 14.79 us / 12.19 KB | 15.22 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.78 us / 11.81 KB | 14.57 us / 11.81 KB | 14.38 us / 11.81 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 13.52 us / 12.19 KB | 13.85 us / 12.19 KB | 13.64 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 13.44 us / 11.81 KB | 13.56 us / 11.81 KB | 13.64 us / 11.81 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 56.69 us / 44.32 KB | 57.29 us / 44.32 KB | 57.57 us / 44.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 60.14 us / 47.90 KB | 56.83 us / 43.87 KB | 55.99 us / 43.87 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 51.31 us / 44.30 KB | 52.51 us / 44.31 KB | 51.28 us / 44.30 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 50.25 us / 43.87 KB | 50.69 us / 43.87 KB | 50.86 us / 43.87 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
