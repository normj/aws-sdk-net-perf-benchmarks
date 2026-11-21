### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f9d95cbfe2617bfd4972e7f376d86e06f87963aa`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e476b0db37ef8af19ea2212b80411fb387a51e5f`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeAsync_JsonPost time, PipelineBenchmarks.InvokeAsync_JsonPost alloc, PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding time, PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding alloc, PipelineBenchmarks.InvokeAsync_JsonPost_Yielding time, PipelineBenchmarks.InvokeAsync_JsonPost_Yielding alloc, PipelineBenchmarks.InvokeAsync_ServiceError_Yielding time, PipelineBenchmarks.InvokeSync_JsonPost alloc, PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders alloc, PipelineBenchmarks.InvokeSync_ServiceError time, PipelineBenchmarks.InvokeSync_ServiceError alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 17.37 us | 15.64 us | 0.90 | faster | 11.77 KB | 11.40 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 34.08 us | 30.21 us | 0.89 | faster | 14.72 KB | 14.34 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 29.06 us | 27.40 us | 0.94 | faster | 13.04 KB | 12.66 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 323.76 us | 293.80 us | 0.91 | faster | 108.49 KB | 108.06 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.68 us | 13.58 us | 0.99 | same | 10.51 KB | 10.13 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 16.34 us | 15.68 us | 0.96 | same | 12.19 KB | 11.81 KB | 0.97 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 63.70 us | 59.60 us | 0.94 | faster | 44.31 KB | 43.87 KB | 0.99 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 17.37 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.64 us / 11.40 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 34.08 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 30.21 us / 14.34 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 29.06 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 27.40 us / 12.66 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 323.76 us / 108.49 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 293.80 us / 108.06 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.68 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.58 us / 10.13 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 16.34 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 15.68 us / 11.81 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 63.70 us / 44.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 59.60 us / 43.87 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
