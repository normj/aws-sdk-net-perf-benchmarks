### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9ebeb7ceb3e31bda8ede587da48ca2451c6b2118`
- Filter: `*RequestSetupBenchmarks.NewRequest*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d156153a1f7aacb652c473f5a25b2cf8df2fd579`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: RequestSetupBenchmarks.NewRequest_Construct time, RequestSetupBenchmarks.NewRequest_Construct alloc, RequestSetupBenchmarks.NewRequest_InvokeAsync alloc, RequestSetupBenchmarks.NewRequest_InvokeSync time, RequestSetupBenchmarks.NewRequest_InvokeSync alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.NewRequest_Construct | net10.0 | 45.63 ns | 7.12 ns | 0.16 | faster | 248 B | 64 B | 0.26 | less |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | 15.74 us | 15.30 us | 0.97 | same | 12.06 KB | 11.88 KB | 0.99 | less |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | 14.09 us | 13.07 us | 0.93 | faster | 10.73 KB | 10.55 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.NewRequest_Construct | net10.0 | base | 45.63 ns / 248 B |
| RequestSetupBenchmarks.NewRequest_Construct | net10.0 | pr | 7.12 ns / 64 B |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | base | 15.74 us / 12.06 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | pr | 15.30 us / 11.88 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | base | 14.09 us / 10.73 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | pr | 13.07 us / 10.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.09 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
