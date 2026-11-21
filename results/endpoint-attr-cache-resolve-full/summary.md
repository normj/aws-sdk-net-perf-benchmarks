### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f02057dd4816993122aa0895d1099bb172ea0b9c`
- Filter: `*EndpointsBenchmarks.*_Resolve*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@47588afb2a861a099dbfa1c270fbda311984485a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 896.64 ns | 879.12 ns | 0.98 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | 835.25 ns | 819.69 ns | 0.98 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.40 us | 3.56 us | 0.81 | faster | 5.33 KB | 4.74 KB | 0.89 | less |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.12 us | 3.24 us | 0.79 | faster | 5.33 KB | 4.74 KB | 0.89 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 1.22 us / 1.64 KB | 866.48 ns / 1.64 KB | 896.64 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 879.12 ns / 1.64 KB | 874.85 ns / 1.64 KB | 929.31 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | base | 815.91 ns / 1.64 KB | 835.25 ns / 1.64 KB | 852.80 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | pr | 816.05 ns / 1.64 KB | 819.69 ns / 1.64 KB | 834.90 ns / 1.64 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.49 us / 5.33 KB | 4.40 us / 5.33 KB | 4.36 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 3.56 us / 4.74 KB | 3.54 us / 4.74 KB | 3.78 us / 4.74 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 4.14 us / 5.33 KB | 4.12 us / 5.33 KB | 4.09 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 3.23 us / 4.74 KB | 3.24 us / 4.74 KB | 3.39 us / 4.74 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.35 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
