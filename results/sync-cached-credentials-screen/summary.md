### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `47367393636853b635f7e3e8de444d97713a6f9d`
- Filter: `*RequestSetupBenchmarks*InvokeAsync*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a4fc535793abb687385c053800ea852ceb6675a1`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.50 us | 2.68 us | 1.07 | **slower** | 2.19 KB | 2.19 KB | 1.00 | same |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.04 us | 1.13 us | 1.09 | **slower** | 1.83 KB | 1.83 KB | 1.00 | same |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | 16.79 us | 16.94 us | 1.01 | same | 12.06 KB | 11.92 KB | 0.99 | less |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | 18.97 us | 20.38 us | 1.07 | **slower** | 12.35 KB | 12.21 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 20.66 us | 20.78 us | 1.01 | same | 16.23 KB | 16.09 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.50 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.68 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.04 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 1.13 us / 1.83 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | base | 16.79 us / 12.06 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | pr | 16.94 us / 11.92 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | base | 18.97 us / 12.35 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | pr | 20.38 us / 12.21 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 20.66 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 20.78 us / 16.09 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
