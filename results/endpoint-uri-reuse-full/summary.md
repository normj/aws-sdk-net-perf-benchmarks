### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d06f331686c289a47d73158c81f19f598b85aec6`
- Filter: `*PipelineBenchmarks.EndpointRules_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c547717a8afccc9417d1a99941aaf2b8d3f9edde`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.4 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | 24.26 us | 21.36 us | 0.88 | same | 13.53 KB | 13.12 KB | 0.97 | less |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | 20.12 us | 19.13 us | 0.95 | same | 12.43 KB | 12.02 KB | 0.97 | less |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | 13.73 us | 12.80 us | 0.93 | faster | 11.00 KB | 10.59 KB | 0.96 | less |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | 12.80 us | 12.18 us | 0.95 | same | 11.00 KB | 10.59 KB | 0.96 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | base | 24.26 us / 13.53 KB | 22.73 us / 13.53 KB | 24.75 us / 13.53 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.57 us / 13.12 KB | 21.36 us / 13.12 KB | 21.13 us / 13.12 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | base | 21.38 us / 12.61 KB | 19.36 us / 12.39 KB | 20.12 us / 12.43 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | pr | 19.44 us / 12.02 KB | 19.13 us / 12.10 KB | 18.56 us / 12.00 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | base | 13.99 us / 11.00 KB | 13.73 us / 11.00 KB | 13.68 us / 11.00 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | pr | 13.34 us / 10.59 KB | 12.80 us / 10.59 KB | 12.69 us / 10.59 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | base | 12.80 us / 11.00 KB | 12.67 us / 11.00 KB | 12.87 us / 11.00 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | pr | 12.44 us / 10.59 KB | 12.18 us / 10.59 KB | 11.98 us / 10.59 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.46 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
