### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d06f331686c289a47d73158c81f19f598b85aec6`
- Filter: `*PipelineBenchmarks.EndpointRules_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c547717a8afccc9417d1a99941aaf2b8d3f9edde`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding time, PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding alloc, PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost time, PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | 24.34 us | 22.33 us | 0.92 | faster | 13.53 KB | 13.12 KB | 0.97 | less |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | 14.02 us | 12.69 us | 0.91 | faster | 11.00 KB | 10.59 KB | 0.96 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | base | 24.39 us / 13.54 KB | 24.28 us / 13.53 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | pr | 22.21 us / 13.12 KB | 22.46 us / 13.12 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | base | 14.34 us / 11.00 KB | 13.70 us / 11.00 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | pr | 12.68 us / 10.59 KB | 12.69 us / 10.59 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
