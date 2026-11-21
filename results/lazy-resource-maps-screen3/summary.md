### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `12630391dbc636760f89c2ceedb64ff1a6feaf8b`
- Filter: `*PipelineBenchmarks.InvokeSync_JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e476b0db37ef8af19ea2212b80411fb387a51e5f`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeSync_JsonPost alloc, PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.70 us | 13.42 us | 0.98 | same | 10.51 KB | 10.27 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.63 us | 15.34 us | 0.98 | same | 12.19 KB | 11.95 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.72 us / 10.51 KB | 13.50 us / 10.51 KB | 13.70 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.42 us / 10.27 KB | 13.40 us / 10.27 KB | 13.80 us / 10.27 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 16.94 us / 12.19 KB | 15.46 us / 12.19 KB | 15.63 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 15.34 us / 11.95 KB | 15.11 us / 11.95 KB | 15.61 us / 11.95 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
