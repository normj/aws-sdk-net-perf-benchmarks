### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `c0d6b50ae6b0880b6ed36504a7bf67ded45ac155`
- Filter: `*RequestSetupBenchmarks.*_InvokeAsync`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a4fc535793abb687385c053800ea852ceb6675a1`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/6 rows faster, 4/6 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | 15.86 us | 15.81 us | 1.00 | same | 12.06 KB | 11.92 KB | 0.99 | less |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | 14.89 us | 14.90 us | 1.00 | same | 11.98 KB | 11.84 KB | 0.99 | less |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | 16.82 us | 16.76 us | 1.00 | same | 12.35 KB | 12.21 KB | 0.99 | less |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | 16.09 us | 15.74 us | 0.98 | same | 12.27 KB | 12.13 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 19.18 us | 19.24 us | 1.00 | same | 16.23 KB | 16.09 KB | 0.99 | same |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | 18.34 us | 18.40 us | 1.00 | same | 16.15 KB | 16.01 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | base | 15.90 us / 12.06 KB | 15.75 us / 12.06 KB | 15.86 us / 12.06 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | pr | 15.60 us / 11.92 KB | 15.81 us / 11.92 KB | 15.98 us / 11.92 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | base | 14.94 us / 11.98 KB | 14.89 us / 11.98 KB | 14.70 us / 11.98 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | pr | 14.84 us / 11.84 KB | 14.90 us / 11.84 KB | 15.63 us / 11.84 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | base | 16.84 us / 12.35 KB | 16.60 us / 12.35 KB | 16.82 us / 12.35 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | pr | 16.63 us / 12.21 KB | 16.76 us / 12.21 KB | 16.82 us / 12.21 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | base | 16.09 us / 12.27 KB | 16.17 us / 12.27 KB | 16.07 us / 12.27 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | pr | 15.74 us / 12.13 KB | 15.70 us / 12.13 KB | 15.88 us / 12.13 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 19.59 us / 16.23 KB | 19.15 us / 16.23 KB | 19.18 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 19.29 us / 16.09 KB | 19.24 us / 16.09 KB | 19.13 us / 16.09 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | base | 18.34 us / 16.15 KB | 18.51 us / 16.15 KB | 18.27 us / 16.15 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | pr | 18.40 us / 16.01 KB | 18.09 us / 16.01 KB | 18.60 us / 16.01 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.64 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.17 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
