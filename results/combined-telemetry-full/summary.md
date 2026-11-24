### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `4759f8d42c9b079d22dbd8294bf48bf2f62fa0a0`
- Filter: `*RequestSetupBenchmarks.Telemetry*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 21.73 us | 20.81 us | 0.96 | same | 16.23 KB | 14.55 KB | 0.90 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | 19.54 us | 19.33 us | 0.99 | same | 16.15 KB | 14.47 KB | 0.90 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 18.14 us | 18.97 us | 1.05 | same | 14.89 KB | 13.21 KB | 0.89 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | 16.90 us | 16.90 us | 1.00 | same | 14.89 KB | 13.21 KB | 0.89 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 21.51 us / 16.23 KB | 21.73 us / 16.23 KB | 30.69 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 21.63 us / 14.55 KB | 20.81 us / 14.55 KB | 20.43 us / 14.55 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | base | 20.16 us / 16.15 KB | 19.54 us / 16.15 KB | 19.43 us / 16.15 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | pr | 20.20 us / 14.47 KB | 19.33 us / 14.47 KB | 18.28 us / 14.47 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 18.14 us / 14.89 KB | 18.80 us / 14.89 KB | 17.84 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 18.97 us / 13.21 KB | 19.24 us / 13.21 KB | 17.49 us / 13.21 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | base | 16.79 us / 14.89 KB | 17.21 us / 14.89 KB | 16.90 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | pr | 17.30 us / 13.21 KB | 16.90 us / 13.21 KB | 15.98 us / 13.21 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.50GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
