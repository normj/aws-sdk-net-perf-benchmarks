### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `75d07ad44f28d19f1442cece36c7b4a16a35993d`
- Filter: `*PipelineBenchmarks.*JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a7197364166f8b20a133957403e53456869d2e5a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 6/10 rows faster, 0/10 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.50 us | 14.58 us | 0.94 | faster | 11.77 KB | 11.77 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.73 us | 13.74 us | 0.93 | faster | 11.77 KB | 11.77 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 26.17 us | 24.98 us | 0.95 | same | 14.72 KB | 14.72 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 21.65 us | 21.19 us | 0.98 | same | 13.81 KB | 13.71 KB | 0.99 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.52 us | 22.39 us | 0.99 | same | 13.04 KB | 13.04 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 20.20 us | 19.51 us | 0.97 | same | 11.98 KB | 11.94 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.35 us | 12.53 us | 0.94 | faster | 10.51 KB | 10.51 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.49 us | 11.52 us | 0.92 | faster | 10.51 KB | 10.51 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.14 us | 14.28 us | 0.94 | faster | 12.19 KB | 12.19 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 13.99 us | 13.18 us | 0.94 | faster | 12.19 KB | 12.19 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 16.19 us / 11.77 KB | 15.50 us / 11.77 KB | 15.49 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.00 us / 11.77 KB | 14.58 us / 11.77 KB | 14.46 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.93 us / 11.77 KB | 14.73 us / 11.77 KB | 14.20 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 13.76 us / 11.77 KB | 13.62 us / 11.77 KB | 13.74 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 31.47 us / 14.72 KB | 24.94 us / 14.72 KB | 26.17 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 29.80 us / 14.72 KB | 24.98 us / 14.72 KB | 24.39 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 24.66 us / 13.81 KB | 21.56 us / 13.70 KB | 21.65 us / 13.83 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 21.32 us / 13.71 KB | 20.18 us / 13.67 KB | 21.19 us / 13.95 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 26.79 us / 13.04 KB | 22.52 us / 13.04 KB | 22.48 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 26.83 us / 13.04 KB | 21.50 us / 13.04 KB | 22.39 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 22.43 us / 11.98 KB | 20.20 us / 11.92 KB | 20.01 us / 12.00 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 19.51 us / 11.94 KB | 18.60 us / 11.92 KB | 19.53 us / 12.01 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 14.28 us / 10.51 KB | 13.35 us / 10.51 KB | 13.28 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.24 us / 10.51 KB | 12.53 us / 10.51 KB | 12.34 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.84 us / 10.51 KB | 12.49 us / 10.51 KB | 12.39 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 11.68 us / 10.51 KB | 11.52 us / 10.51 KB | 11.48 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 16.06 us / 12.19 KB | 15.14 us / 12.19 KB | 14.94 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.93 us / 12.19 KB | 14.28 us / 12.19 KB | 14.05 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 14.97 us / 12.19 KB | 13.99 us / 12.19 KB | 13.99 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 13.18 us / 12.19 KB | 13.10 us / 12.19 KB | 13.26 us / 12.19 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.31 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
