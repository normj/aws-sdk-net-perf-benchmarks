### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `df1a756fcebb46a50e3a337333bf48416d7d9ab6`
- Filter: `*PipelineBenchmarks.EndpointDiscovery_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | 23.96 us | 22.17 us | 0.93 | faster | 13.70 KB | 12.95 KB | 0.94 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | 20.75 us | 21.06 us | 1.02 | same | 12.56 KB | 11.84 KB | 0.94 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | 14.18 us | 13.43 us | 0.95 | faster | 11.13 KB | 10.38 KB | 0.93 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | 13.11 us | 12.61 us | 0.96 | same | 11.12 KB | 10.37 KB | 0.93 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | base | 23.66 us / 13.70 KB | 24.53 us / 13.70 KB | 23.96 us / 13.70 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | pr | 22.68 us / 12.95 KB | 21.07 us / 12.95 KB | 22.17 us / 12.95 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | base | 21.35 us / 12.80 KB | 20.13 us / 12.56 KB | 20.75 us / 12.56 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | pr | 21.71 us / 11.85 KB | 20.88 us / 11.83 KB | 21.06 us / 11.84 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | base | 14.00 us / 11.13 KB | 14.23 us / 11.13 KB | 14.18 us / 11.13 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | pr | 13.43 us / 10.38 KB | 13.43 us / 10.38 KB | 13.60 us / 10.38 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | base | 13.29 us / 11.12 KB | 13.11 us / 11.12 KB | 12.93 us / 11.12 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | pr | 12.61 us / 10.37 KB | 12.33 us / 10.37 KB | 12.93 us / 10.37 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.02 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
