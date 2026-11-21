### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `916cdb605c30e80b6e9e54423abc4da71ad596ff`
- Filter: `*PipelineBenchmarks.*JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3c2f90419fc0f4eac2add461284ac4465322a13f`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeAsync_JsonPost alloc, PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding alloc, PipelineBenchmarks.InvokeAsync_JsonPost_Yielding alloc, PipelineBenchmarks.InvokeSync_JsonPost alloc, PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 16.78 us | 16.36 us | 0.97 | same | 11.77 KB | 11.59 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 34.45 us | 37.50 us | 1.09 | same | 14.72 KB | 14.53 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 28.01 us | 29.43 us | 1.05 | same | 13.04 KB | 12.85 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 14.20 us | 13.62 us | 0.96 | same | 10.51 KB | 10.32 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 16.15 us | 17.46 us | 1.08 | same | 12.19 KB | 12.00 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 16.74 us / 11.77 KB | 16.83 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 16.65 us / 11.59 KB | 16.06 us / 11.59 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 36.42 us / 14.72 KB | 32.49 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 44.26 us / 14.53 KB | 30.74 us / 14.53 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 27.00 us / 13.04 KB | 29.02 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 33.08 us / 12.85 KB | 25.77 us / 12.85 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.97 us / 10.51 KB | 14.43 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.60 us / 10.32 KB | 13.64 us / 10.32 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 15.72 us / 12.19 KB | 16.59 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 19.36 us / 12.00 KB | 15.55 us / 12.00 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.23 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
