### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f18d3c256444ff90e2cfb1c208d134ceb76d6cd1`
- Filter: `*EndpointsBenchmarks.*_Resolve*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@47588afb2a861a099dbfa1c270fbda311984485a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 869.35 ns | 863.86 ns | 0.99 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | 850.38 ns | 847.99 ns | 1.00 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.50 us | 3.14 us | 0.70 | faster | 5.33 KB | 4.69 KB | 0.88 | less |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.14 us | 2.90 us | 0.70 | faster | 5.33 KB | 4.69 KB | 0.88 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 894.80 ns / 1.64 KB | 862.70 ns / 1.64 KB | 869.35 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 863.77 ns / 1.64 KB | 868.49 ns / 1.64 KB | 863.86 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | base | 1.43 us / 1.64 KB | 835.80 ns / 1.64 KB | 850.38 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | pr | 854.34 ns / 1.64 KB | 847.99 ns / 1.64 KB | 822.38 ns / 1.64 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.50 us / 5.33 KB | 4.42 us / 5.33 KB | 4.54 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 3.11 us / 4.69 KB | 3.14 us / 4.69 KB | 3.18 us / 4.69 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 6.14 us / 5.33 KB | 4.14 us / 5.33 KB | 4.09 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 2.90 us / 4.69 KB | 2.93 us / 4.69 KB | 2.84 us / 4.69 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
