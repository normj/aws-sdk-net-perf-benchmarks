### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `12630391dbc636760f89c2ceedb64ff1a6feaf8b`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e476b0db37ef8af19ea2212b80411fb387a51e5f`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.77 us | 15.40 us | 0.98 | same | 11.77 KB | 11.54 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 29.93 us | 30.48 us | 1.02 | same | 14.72 KB | 14.48 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 25.55 us | 25.06 us | 0.98 | same | 13.04 KB | 12.80 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 273.77 us | 297.05 us | 1.09 | **slower** | 108.48 KB | 108.23 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.34 us | 13.20 us | 0.99 | same | 10.51 KB | 10.27 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.72 us | 22.29 us | 1.42 | **slower** | 12.19 KB | 11.95 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 57.79 us | 77.73 us | 1.35 | **slower** | 44.31 KB | 44.00 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.77 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.40 us / 11.54 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 29.93 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 30.48 us / 14.48 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 25.55 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 25.06 us / 12.80 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 273.77 us / 108.48 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 297.05 us / 108.23 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.34 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.20 us / 10.27 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 15.72 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 22.29 us / 11.95 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 57.79 us / 44.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 77.73 us / 44.00 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
