### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `58e19a7bd55d157e94d34a88b39bddba8c8cb39f`
- Filter: `*PipelineBenchmarks.Invoke*JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a4fc535793abb687385c053800ea852ceb6675a1`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.4 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/10 rows faster, 6/10 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.31 us | 15.36 us | 1.00 | same | 11.77 KB | 11.61 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.42 us | 14.23 us | 0.99 | same | 11.77 KB | 11.61 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 25.94 us | 26.63 us | 1.03 | same | 14.72 KB | 14.55 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 21.64 us | 21.88 us | 1.01 | same | 13.72 KB | 13.55 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.00 us | 22.58 us | 1.03 | same | 13.04 KB | 12.88 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.07 us | 18.98 us | 0.99 | same | 11.91 KB | 11.77 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.24 us | 13.23 us | 1.00 | same | 10.51 KB | 10.41 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.55 us | 12.47 us | 0.99 | same | 10.51 KB | 10.41 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.09 us | 14.99 us | 0.99 | same | 12.19 KB | 12.09 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 14.02 us | 14.05 us | 1.00 | same | 12.19 KB | 12.09 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.31 us / 11.77 KB | 15.42 us / 11.77 KB | 15.29 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.69 us / 11.61 KB | 15.30 us / 11.61 KB | 15.36 us / 11.61 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.27 us / 11.77 KB | 14.50 us / 11.77 KB | 14.42 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 14.18 us / 11.61 KB | 14.23 us / 11.61 KB | 14.28 us / 11.61 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 26.36 us / 14.72 KB | 25.94 us / 14.72 KB | 25.72 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 26.86 us / 14.55 KB | 26.63 us / 14.55 KB | 25.00 us / 14.55 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 22.57 us / 13.69 KB | 21.64 us / 13.74 KB | 21.00 us / 13.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 22.62 us / 13.51 KB | 21.88 us / 13.58 KB | 20.85 us / 13.55 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 21.22 us / 13.04 KB | 22.00 us / 13.04 KB | 23.07 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 22.76 us / 12.87 KB | 22.58 us / 12.88 KB | 22.58 us / 12.88 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 18.69 us / 11.91 KB | 19.07 us / 11.91 KB | 19.39 us / 11.98 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 19.02 us / 11.76 KB | 18.98 us / 11.80 KB | 18.90 us / 11.77 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.15 us / 10.51 KB | 13.24 us / 10.51 KB | 13.29 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.63 us / 10.41 KB | 13.12 us / 10.41 KB | 13.23 us / 10.41 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.55 us / 10.51 KB | 12.65 us / 10.51 KB | 12.44 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 12.45 us / 10.41 KB | 12.58 us / 10.41 KB | 12.47 us / 10.41 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 15.12 us / 12.19 KB | 14.84 us / 12.19 KB | 15.09 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 15.37 us / 12.09 KB | 14.99 us / 12.09 KB | 14.80 us / 12.09 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 14.02 us / 12.19 KB | 14.21 us / 12.19 KB | 13.91 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 14.05 us / 12.09 KB | 14.11 us / 12.09 KB | 14.05 us / 12.09 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.55 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
