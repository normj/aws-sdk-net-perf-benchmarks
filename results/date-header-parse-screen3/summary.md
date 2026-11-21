### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `75d07ad44f28d19f1442cece36c7b4a16a35993d`
- Filter: `*PipelineBenchmarks.*JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3f5092230dd561332f867e9a978a4fe4688cc3ab`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeAsync_JsonPost time, PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding time, PipelineBenchmarks.InvokeAsync_JsonPost_Yielding time, PipelineBenchmarks.InvokeSync_JsonPost time.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.55 us | 14.75 us | 0.95 | faster | 11.77 KB | 11.77 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 26.92 us | 25.21 us | 0.94 | faster | 14.72 KB | 14.72 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.77 us | 20.88 us | 0.92 | faster | 13.04 KB | 13.04 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.46 us | 12.49 us | 0.93 | faster | 10.51 KB | 10.51 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.01 us | 14.40 us | 0.96 | same | 12.19 KB | 12.19 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.37 us / 11.77 KB | 15.74 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 14.98 us / 11.77 KB | 14.52 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 27.14 us / 14.72 KB | 26.71 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 25.28 us / 14.72 KB | 25.14 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 23.59 us / 13.04 KB | 21.96 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 20.53 us / 13.04 KB | 21.23 us / 13.04 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.29 us / 10.51 KB | 13.62 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 12.62 us / 10.51 KB | 12.36 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 15.10 us / 12.19 KB | 14.91 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.66 us / 12.19 KB | 14.15 us / 12.19 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.46 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
