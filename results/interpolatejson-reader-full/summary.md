### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `801e615cfcd30c2b3295362f22f36b670773085d`
- Filter: `*EndpointsBenchmarks.*Resolve*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 869.98 ns | 877.44 ns | 1.01 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | 833.18 ns | 819.94 ns | 0.98 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.45 us | 3.83 us | 0.86 | faster | 5.33 KB | 4.73 KB | 0.89 | less |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.14 us | 3.54 us | 0.85 | faster | 5.33 KB | 4.73 KB | 0.89 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 869.98 ns / 1.64 KB | 888.08 ns / 1.64 KB | 863.32 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 929.16 ns / 1.64 KB | 877.44 ns / 1.64 KB | 866.32 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | base | 896.85 ns / 1.64 KB | 833.18 ns / 1.64 KB | 827.62 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | pr | 881.28 ns / 1.64 KB | 819.94 ns / 1.64 KB | 814.19 ns / 1.64 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.41 us / 5.33 KB | 4.61 us / 5.33 KB | 4.45 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 4.01 us / 4.73 KB | 3.81 us / 4.73 KB | 3.83 us / 4.73 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 4.14 us / 5.33 KB | 4.14 us / 5.33 KB | 4.08 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 3.88 us / 4.73 KB | 3.52 us / 4.73 KB | 3.54 us / 4.73 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
