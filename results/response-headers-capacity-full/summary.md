### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `800f48b75bf02980fecc4940166cfc7dfcfba596`
- Filter: `*PipelineBenchmarks.*JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3c2f90419fc0f4eac2add461284ac4465322a13f`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/10 rows faster, 6/10 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 16.06 us | 15.53 us | 0.97 | same | 11.77 KB | 11.66 KB | 0.99 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.30 us | 14.28 us | 1.00 | same | 11.77 KB | 11.66 KB | 0.99 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 33.07 us | 25.58 us | 0.77 | same | 14.72 KB | 14.20 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 22.92 us | 22.20 us | 0.97 | same | 13.69 KB | 13.32 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 24.98 us | 22.78 us | 0.91 | same | 13.04 KB | 12.93 KB | 0.99 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.84 us | 20.65 us | 1.04 | same | 11.95 KB | 11.92 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 14.04 us | 13.37 us | 0.95 | same | 10.51 KB | 10.40 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.57 us | 12.24 us | 0.97 | same | 10.51 KB | 10.40 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.47 us | 15.07 us | 0.97 | same | 12.19 KB | 11.67 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 13.93 us | 13.89 us | 1.00 | same | 12.19 KB | 11.67 KB | 0.96 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 16.48 us / 11.77 KB | 15.11 us / 11.77 KB | 16.06 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.53 us / 11.66 KB | 15.24 us / 11.66 KB | 15.61 us / 11.66 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.89 us / 11.77 KB | 14.30 us / 11.77 KB | 14.23 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 14.28 us / 11.66 KB | 14.60 us / 11.66 KB | 14.19 us / 11.66 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 33.07 us / 14.72 KB | 25.76 us / 14.72 KB | 39.16 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 25.58 us / 14.20 KB | 25.94 us / 14.20 KB | 25.07 us / 14.20 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 23.60 us / 13.77 KB | 22.92 us / 13.61 KB | 21.54 us / 13.69 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 22.20 us / 13.32 KB | 26.97 us / 13.28 KB | 21.58 us / 13.34 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 24.98 us / 13.04 KB | 22.24 us / 13.04 KB | 32.95 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 22.78 us / 12.93 KB | 22.84 us / 12.93 KB | 21.47 us / 12.93 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 31.00 us / 12.03 KB | 18.85 us / 11.91 KB | 19.84 us / 11.95 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 20.65 us / 11.86 KB | 24.93 us / 12.00 KB | 19.76 us / 11.92 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 14.31 us / 10.51 KB | 13.22 us / 10.51 KB | 14.04 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.37 us / 10.40 KB | 13.24 us / 10.40 KB | 13.44 us / 10.40 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 13.02 us / 10.51 KB | 12.22 us / 10.51 KB | 12.57 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 12.49 us / 10.40 KB | 12.24 us / 10.40 KB | 12.19 us / 10.40 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 15.47 us / 12.19 KB | 14.86 us / 12.19 KB | 15.63 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 15.07 us / 11.67 KB | 14.71 us / 11.67 KB | 15.28 us / 11.67 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 13.95 us / 12.19 KB | 13.91 us / 12.19 KB | 13.93 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 13.89 us / 11.67 KB | 14.73 us / 11.67 KB | 13.83 us / 11.67 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
