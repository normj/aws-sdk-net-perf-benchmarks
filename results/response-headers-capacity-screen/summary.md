### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `800f48b75bf02980fecc4940166cfc7dfcfba596`
- Filter: `*PipelineBenchmarks.*JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3c2f90419fc0f4eac2add461284ac4465322a13f`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding alloc, PipelineBenchmarks.InvokeAsync_JsonPost_Yielding time, PipelineBenchmarks.InvokeSync_JsonPost alloc, PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.40 us | 15.67 us | 1.02 | same | 11.77 KB | 11.66 KB | 0.99 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 25.27 us | 25.28 us | 1.00 | same | 14.72 KB | 14.20 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 24.02 us | 21.70 us | 0.90 | faster | 13.04 KB | 12.93 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.10 us | 13.22 us | 1.01 | same | 10.51 KB | 10.40 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 14.91 us | 14.99 us | 1.01 | same | 12.19 KB | 11.67 KB | 0.96 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.29 us / 11.77 KB | 15.51 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.29 us / 11.66 KB | 16.05 us / 11.66 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 25.62 us / 14.72 KB | 24.93 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 25.25 us / 14.20 KB | 25.32 us / 14.20 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 24.71 us / 13.04 KB | 23.33 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 21.06 us / 12.93 KB | 22.33 us / 12.93 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.14 us / 10.51 KB | 13.06 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.07 us / 10.40 KB | 13.37 us / 10.40 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 15.12 us / 12.19 KB | 14.69 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.74 us / 11.67 KB | 15.24 us / 11.67 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
