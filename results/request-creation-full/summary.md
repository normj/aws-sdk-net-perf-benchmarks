### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `916cdb605c30e80b6e9e54423abc4da71ad596ff`
- Filter: `*PipelineBenchmarks.*JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3c2f90419fc0f4eac2add461284ac4465322a13f`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/10 rows faster, 8/10 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.29 us | 15.11 us | 0.99 | same | 11.77 KB | 11.59 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.15 us | 14.23 us | 1.01 | same | 11.77 KB | 11.58 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 26.39 us | 24.91 us | 0.94 | faster | 14.72 KB | 14.53 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 21.54 us | 21.39 us | 0.99 | same | 13.70 KB | 13.62 KB | 0.99 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.95 us | 22.49 us | 0.98 | same | 13.04 KB | 12.85 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.30 us | 19.48 us | 1.01 | same | 11.91 KB | 11.77 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.18 us | 12.93 us | 0.98 | same | 10.51 KB | 10.32 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.31 us | 12.17 us | 0.99 | same | 10.51 KB | 10.32 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 14.97 us | 14.69 us | 0.98 | same | 12.19 KB | 12.00 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 13.83 us | 13.78 us | 1.00 | same | 12.19 KB | 12.00 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.49 us / 11.77 KB | 15.29 us / 11.77 KB | 15.22 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 14.89 us / 11.59 KB | 15.11 us / 11.59 KB | 15.47 us / 11.59 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.15 us / 11.77 KB | 14.25 us / 11.77 KB | 14.10 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 14.00 us / 11.58 KB | 14.23 us / 11.58 KB | 14.29 us / 11.58 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 28.90 us / 14.72 KB | 25.70 us / 14.72 KB | 26.39 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 25.00 us / 14.53 KB | 24.91 us / 14.53 KB | 24.38 us / 14.53 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 21.54 us / 13.78 KB | 22.15 us / 13.67 KB | 21.33 us / 13.70 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 21.36 us / 13.54 KB | 21.39 us / 13.62 KB | 22.31 us / 13.63 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 24.81 us / 13.04 KB | 22.77 us / 13.04 KB | 22.95 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 22.20 us / 12.85 KB | 22.49 us / 12.85 KB | 22.70 us / 12.85 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 19.30 us / 11.93 KB | 18.97 us / 11.91 KB | 20.68 us / 11.91 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 18.51 us / 11.73 KB | 19.48 us / 11.77 KB | 22.96 us / 12.03 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.56 us / 10.51 KB | 13.18 us / 10.51 KB | 13.18 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 12.70 us / 10.32 KB | 13.29 us / 10.32 KB | 12.93 us / 10.32 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.21 us / 10.51 KB | 12.31 us / 10.51 KB | 12.38 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 12.17 us / 10.32 KB | 12.11 us / 10.32 KB | 12.30 us / 10.32 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 19.99 us / 12.19 KB | 14.97 us / 12.19 KB | 14.89 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.69 us / 12.00 KB | 14.86 us / 12.00 KB | 14.68 us / 12.00 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 13.83 us / 12.19 KB | 13.85 us / 12.19 KB | 13.81 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 13.72 us / 12.00 KB | 13.78 us / 12.00 KB | 13.88 us / 12.00 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.92 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
