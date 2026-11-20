### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `7a5f7737faabceb5cb0c96500aa38ed5d8e157f4`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@6a5b1db5aeef9039ca9287fb1a6b7d78b7b2943c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/6 rows faster, 4/6 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.80 us | 15.46 us | 0.98 | same | 11.77 KB | 11.49 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.68 us | 14.32 us | 0.98 | same | 11.77 KB | 11.48 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 24.26 us | 23.17 us | 0.96 | same | 13.04 KB | 12.54 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.84 us | 19.79 us | 1.00 | same | 11.93 KB | 11.64 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 14.82 us | 13.55 us | 0.91 | same | 10.51 KB | 10.51 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.47 us | 12.34 us | 0.99 | same | 10.51 KB | 10.51 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.74 us / 11.77 KB | 15.80 us / 11.77 KB | 16.31 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.46 us / 11.49 KB | 15.71 us / 11.49 KB | 15.03 us / 11.49 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.68 us / 11.77 KB | 14.52 us / 11.77 KB | 22.66 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 14.27 us / 11.48 KB | 14.50 us / 11.48 KB | 14.32 us / 11.48 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 22.95 us / 13.04 KB | 24.26 us / 13.04 KB | 31.09 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.17 us / 12.54 KB | 23.49 us / 12.54 KB | 21.34 us / 12.54 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 19.55 us / 11.93 KB | 19.84 us / 11.91 KB | 43.43 us / 12.92 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 19.79 us / 11.63 KB | 20.05 us / 11.64 KB | 19.10 us / 11.66 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 15.22 us / 10.51 KB | 14.82 us / 10.51 KB | 13.62 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.28 us / 10.51 KB | 13.67 us / 10.51 KB | 13.55 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.43 us / 10.51 KB | 12.47 us / 10.51 KB | 14.57 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 12.34 us / 10.51 KB | 14.40 us / 10.51 KB | 12.25 us / 10.51 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.68 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.89 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
