### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `80e379872e1e498f7cfa976aa82dd0ba04f4a331`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e476b0db37ef8af19ea2212b80411fb387a51e5f`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.4 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeAsync_JsonPost alloc, PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding alloc, PipelineBenchmarks.InvokeAsync_JsonPost_Yielding alloc, PipelineBenchmarks.InvokeSync_JsonPost alloc, PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders alloc, PipelineBenchmarks.InvokeSync_ServiceError alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.38 us | 15.38 us | 1.00 | same | 11.77 KB | 11.37 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 25.34 us | 24.82 us | 0.98 | same | 14.72 KB | 14.31 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.05 us | 21.24 us | 0.96 | same | 13.04 KB | 12.63 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 254.14 us | 250.90 us | 0.99 | same | 108.48 KB | 108.05 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.66 us | 13.07 us | 0.96 | same | 10.51 KB | 10.10 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 14.96 us | 15.00 us | 1.00 | same | 12.19 KB | 11.78 KB | 0.97 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 56.91 us | 57.27 us | 1.01 | same | 44.31 KB | 43.83 KB | 0.99 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.35 us / 11.77 KB | 15.40 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.61 us / 11.37 KB | 15.14 us / 11.37 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 25.92 us / 14.72 KB | 24.76 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 25.14 us / 14.31 KB | 24.50 us / 14.31 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 22.83 us / 13.04 KB | 21.26 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 20.92 us / 12.63 KB | 21.55 us / 12.63 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 256.83 us / 108.46 KB | 251.45 us / 108.49 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 254.03 us / 108.05 KB | 247.77 us / 108.04 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 14.35 us / 10.51 KB | 12.98 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.25 us / 10.10 KB | 12.90 us / 10.10 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 14.98 us / 12.19 KB | 14.94 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 15.19 us / 11.78 KB | 14.82 us / 11.78 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 57.40 us / 44.31 KB | 56.41 us / 44.32 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 57.61 us / 43.83 KB | 56.93 us / 43.83 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
