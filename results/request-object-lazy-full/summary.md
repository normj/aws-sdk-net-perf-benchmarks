### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9ebeb7ceb3e31bda8ede587da48ca2451c6b2118`
- Filter: `*RequestSetupBenchmarks.NewRequest*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d156153a1f7aacb652c473f5a25b2cf8df2fd579`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/6 rows faster, 6/6 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.NewRequest_Construct | net10.0 | 40.96 ns | 6.85 ns | 0.17 | faster | 248 B | 64 B | 0.26 | less |
| RequestSetupBenchmarks.NewRequest_Construct | net11.0 | 35.62 ns | 7.12 ns | 0.20 | faster | 248 B | 64 B | 0.26 | less |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | 15.55 us | 15.34 us | 0.99 | same | 12.06 KB | 11.88 KB | 0.99 | less |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | 14.47 us | 14.43 us | 1.00 | same | 11.98 KB | 11.80 KB | 0.99 | less |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | 13.07 us | 13.29 us | 1.02 | same | 10.73 KB | 10.55 KB | 0.98 | less |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | 12.29 us | 12.37 us | 1.01 | same | 10.73 KB | 10.55 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.NewRequest_Construct | net10.0 | base | 41.70 ns / 248 B | 40.96 ns / 248 B | 40.34 ns / 248 B |
| RequestSetupBenchmarks.NewRequest_Construct | net10.0 | pr | 6.85 ns / 64 B | 6.83 ns / 64 B | 7.38 ns / 64 B |
| RequestSetupBenchmarks.NewRequest_Construct | net11.0 | base | 35.62 ns / 248 B | 35.62 ns / 248 B | 35.50 ns / 248 B |
| RequestSetupBenchmarks.NewRequest_Construct | net11.0 | pr | 7.70 ns / 64 B | 6.43 ns / 64 B | 7.12 ns / 64 B |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | base | 15.63 us / 12.06 KB | 15.55 us / 12.06 KB | 15.43 us / 12.06 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | pr | 15.34 us / 11.88 KB | 15.54 us / 11.88 KB | 15.33 us / 11.88 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | base | 14.46 us / 11.98 KB | 14.47 us / 11.98 KB | 14.58 us / 11.98 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | pr | 14.43 us / 11.80 KB | 14.16 us / 11.80 KB | 14.64 us / 11.80 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | base | 13.12 us / 10.73 KB | 13.07 us / 10.73 KB | 13.06 us / 10.73 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | pr | 13.09 us / 10.55 KB | 13.40 us / 10.55 KB | 13.29 us / 10.55 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | base | 12.29 us / 10.73 KB | 12.50 us / 10.73 KB | 12.26 us / 10.73 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | pr | 12.37 us / 10.55 KB | 12.38 us / 10.55 KB | 12.35 us / 10.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
