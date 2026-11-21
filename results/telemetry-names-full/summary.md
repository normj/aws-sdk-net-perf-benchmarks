### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `8a7965d1f58b79617296e3afaf6f714e9360eaa8`
- Filter: `*RequestSetupBenchmarks.Telemetry*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@5f0bd7f0bebbca0d4f383128b0edbd53b6ad916c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 20.06 us | 19.71 us | 0.98 | same | 16.23 KB | 14.78 KB | 0.91 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | 18.35 us | 18.35 us | 1.00 | same | 16.15 KB | 14.70 KB | 0.91 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 17.01 us | 17.24 us | 1.01 | same | 14.89 KB | 13.45 KB | 0.90 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | 16.12 us | 15.82 us | 0.98 | same | 14.89 KB | 13.45 KB | 0.90 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 21.03 us / 16.23 KB | 20.06 us / 16.23 KB | 19.63 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 19.92 us / 14.78 KB | 19.71 us / 14.78 KB | 19.71 us / 14.78 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | base | 18.87 us / 16.15 KB | 18.35 us / 16.15 KB | 18.13 us / 16.15 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | pr | 18.50 us / 14.70 KB | 18.00 us / 14.70 KB | 18.35 us / 14.70 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 17.65 us / 14.89 KB | 17.01 us / 14.89 KB | 16.93 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 17.86 us / 13.45 KB | 17.04 us / 13.45 KB | 17.24 us / 13.45 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | base | 16.30 us / 14.89 KB | 16.00 us / 14.89 KB | 16.12 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | pr | 16.16 us / 13.45 KB | 15.82 us / 13.45 KB | 15.73 us / 13.45 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.27 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.19 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
