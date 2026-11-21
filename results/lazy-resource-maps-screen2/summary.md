### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `12630391dbc636760f89c2ceedb64ff1a6feaf8b`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e476b0db37ef8af19ea2212b80411fb387a51e5f`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.48 us | 19.85 us | 1.28 | **slower** | 11.77 KB | 11.54 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 27.81 us | 38.70 us | 1.39 | same | 14.72 KB | 14.48 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 23.99 us | 34.66 us | 1.44 | same | 13.04 KB | 12.80 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 291.83 us | 282.05 us | 0.97 | same | 108.54 KB | 108.22 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.62 us | 13.35 us | 0.98 | same | 10.51 KB | 10.27 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.22 us | 21.24 us | 1.40 | same | 12.19 KB | 11.95 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 57.69 us | 62.45 us | 1.08 | same | 44.32 KB | 44.00 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.34 us / 11.77 KB | 15.61 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.62 us / 11.54 KB | 24.08 us / 11.54 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 24.67 us / 14.72 KB | 30.94 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 26.21 us / 14.48 KB | 51.19 us / 14.48 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 22.04 us / 13.04 KB | 25.95 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.55 us / 12.80 KB | 45.77 us / 12.80 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 249.50 us / 108.58 KB | 334.15 us / 108.50 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 254.60 us / 108.20 KB | 309.51 us / 108.25 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.28 us / 10.51 KB | 13.96 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 12.87 us / 10.27 KB | 13.83 us / 10.27 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 14.93 us / 12.19 KB | 15.51 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.70 us / 11.95 KB | 27.79 us / 11.95 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 57.14 us / 44.32 KB | 58.24 us / 44.32 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 57.05 us / 44.00 KB | 67.85 us / 44.00 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
