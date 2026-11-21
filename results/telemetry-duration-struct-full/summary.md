### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d510effa73fcf00781c99376bb540a37f4b8f620`
- Filter: `*RequestSetupBenchmarks.Telemetry*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a4fc535793abb687385c053800ea852ceb6675a1`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 19.76 us | 19.67 us | 1.00 | same | 16.23 KB | 15.99 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | 18.48 us | 18.56 us | 1.00 | same | 16.15 KB | 15.92 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 17.11 us | 17.00 us | 0.99 | same | 14.89 KB | 14.66 KB | 0.98 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | 16.53 us | 16.11 us | 0.97 | same | 14.89 KB | 14.66 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 19.69 us / 16.23 KB | 19.89 us / 16.23 KB | 19.76 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 21.98 us / 15.99 KB | 19.67 us / 15.99 KB | 19.29 us / 15.99 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | base | 19.26 us / 16.15 KB | 18.48 us / 16.15 KB | 18.12 us / 16.15 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | pr | 20.46 us / 15.92 KB | 18.56 us / 15.92 KB | 18.23 us / 15.92 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 17.08 us / 14.89 KB | 17.11 us / 14.89 KB | 17.16 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 18.23 us / 14.66 KB | 16.69 us / 14.66 KB | 17.00 us / 14.66 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | base | 16.89 us / 14.89 KB | 16.53 us / 14.89 KB | 15.88 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | pr | 16.91 us / 14.66 KB | 15.67 us / 14.66 KB | 16.11 us / 14.66 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.59 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
