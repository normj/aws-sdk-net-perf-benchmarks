### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `75d07ad44f28d19f1442cece36c7b4a16a35993d`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3c2f90419fc0f4eac2add461284ac4465322a13f`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.31 us | 14.56 us | 0.95 | same | 11.77 KB | 11.77 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 26.89 us | 25.14 us | 0.94 | faster | 14.72 KB | 14.72 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.48 us | 21.72 us | 0.97 | same | 13.04 KB | 13.04 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 255.42 us | 248.76 us | 0.97 | same | 108.47 KB | 108.43 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.18 us | 12.36 us | 0.94 | faster | 10.51 KB | 10.51 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.03 us | 14.37 us | 0.96 | same | 12.19 KB | 12.19 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 57.83 us | 57.78 us | 1.00 | same | 44.31 KB | 46.32 KB | 1.05 | **more** |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.34 us / 11.77 KB | 15.28 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 14.38 us / 11.77 KB | 14.73 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 26.24 us / 14.72 KB | 27.53 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 24.29 us / 14.72 KB | 25.99 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 22.13 us / 13.04 KB | 22.82 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 20.93 us / 13.04 KB | 22.52 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 252.09 us / 108.46 KB | 258.74 us / 108.49 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 248.90 us / 108.41 KB | 248.62 us / 108.45 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.09 us / 10.51 KB | 13.27 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 12.28 us / 10.51 KB | 12.43 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 14.98 us / 12.19 KB | 15.08 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.36 us / 12.19 KB | 14.38 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 57.40 us / 44.31 KB | 58.25 us / 44.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 57.98 us / 46.32 KB | 57.57 us / 46.32 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
