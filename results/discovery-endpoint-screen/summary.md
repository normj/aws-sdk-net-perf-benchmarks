### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `df1a756fcebb46a50e3a337333bf48416d7d9ab6`
- Filter: `*PipelineBenchmarks.EndpointDiscovery_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding time, PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding alloc, PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost time, PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | 24.90 us | 23.28 us | 0.94 | faster | 13.70 KB | 12.95 KB | 0.94 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | 14.22 us | 13.44 us | 0.95 | faster | 11.13 KB | 10.38 KB | 0.93 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | base | 25.78 us / 13.70 KB | 24.01 us / 13.70 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.97 us / 12.95 KB | 22.59 us / 12.95 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | base | 14.24 us / 11.13 KB | 14.19 us / 11.13 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | pr | 13.76 us / 10.38 KB | 13.12 us / 10.38 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
