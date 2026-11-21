### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `3faff12714d728a9e770dd979eff50c4669694f8`
- Filter: `*EndpointsBenchmarks.ParseArn*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@47588afb2a861a099dbfa1c270fbda311984485a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | 384.32 ns | 251.21 ns | 0.65 | faster | 1.06 KB | 560 B | 0.51 | less |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | 363.22 ns | 237.25 ns | 0.65 | faster | 1.06 KB | 560 B | 0.51 | less |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | 11.39 ns | 11.09 ns | 0.97 | same | 0 B | 0 B | 1.00 | same |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | 11.36 ns | 11.22 ns | 0.99 | same | 0 B | 0 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | base | 384.32 ns / 1.06 KB | 392.66 ns / 1.06 KB | 382.59 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | pr | 249.99 ns / 560 B | 251.21 ns / 560 B | 254.79 ns / 560 B |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | base | 390.50 ns / 1.06 KB | 361.21 ns / 1.06 KB | 363.22 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | pr | 239.93 ns / 560 B | 237.25 ns / 560 B | 235.86 ns / 560 B |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | base | 11.39 ns / 0 B | 11.17 ns / 0 B | 11.55 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | pr | 11.14 ns / 0 B | 11.09 ns / 0 B | 11.07 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | base | 11.30 ns / 0 B | 11.45 ns / 0 B | 11.36 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | pr | 10.97 ns / 0 B | 11.72 ns / 0 B | 11.22 ns / 0 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.1 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
