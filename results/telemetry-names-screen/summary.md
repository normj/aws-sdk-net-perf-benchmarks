### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `8a7965d1f58b79617296e3afaf6f714e9360eaa8`
- Filter: `*RequestSetupBenchmarks.Telemetry*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@5f0bd7f0bebbca0d4f383128b0edbd53b6ad916c`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: RequestSetupBenchmarks.Telemetry_InvokeAsync alloc, RequestSetupBenchmarks.Telemetry_InvokeSync alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 20.46 us | 20.50 us | 1.00 | same | 16.23 KB | 14.78 KB | 0.91 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 17.59 us | 17.58 us | 1.00 | same | 14.89 KB | 13.45 KB | 0.90 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 20.46 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 20.50 us / 14.78 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 17.59 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 17.58 us / 13.45 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
