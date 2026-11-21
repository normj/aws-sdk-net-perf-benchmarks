### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `47367393636853b635f7e3e8de444d97713a6f9d`
- Filter: `*RequestSetupBenchmarks.*_InvokeAsync`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a4fc535793abb687385c053800ea852ceb6675a1`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: RequestSetupBenchmarks.NewRequest_InvokeAsync alloc, RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | 15.74 us | 16.20 us | 1.03 | same | 12.06 KB | 11.92 KB | 0.99 | less |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | 16.54 us | 17.17 us | 1.04 | same | 12.35 KB | 12.21 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 19.23 us | 19.33 us | 1.01 | same | 16.23 KB | 16.09 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | base | 15.74 us / 12.06 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | pr | 16.20 us / 11.92 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | base | 16.54 us / 12.35 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | pr | 17.17 us / 12.21 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 19.23 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 19.33 us / 16.09 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
