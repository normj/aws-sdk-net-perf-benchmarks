### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d510effa73fcf00781c99376bb540a37f4b8f620`
- Filter: `*RequestSetupBenchmarks.Telemetry*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3f5092230dd561332f867e9a978a4fe4688cc3ab`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: RequestSetupBenchmarks.Telemetry_InvokeAsync alloc, RequestSetupBenchmarks.Telemetry_InvokeSync alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 20.63 us | 20.04 us | 0.97 | same | 16.23 KB | 15.99 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 17.78 us | 17.65 us | 0.99 | same | 14.89 KB | 14.66 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 20.63 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 20.04 us / 15.99 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 17.78 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 17.65 us / 14.66 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
