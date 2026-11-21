### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `bae3f9427bba5f9865978ac8c7f525ff1a3d6725`
- Filter: `*EndpointsBenchmarks.*_Resolve*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@2035ceb1abcc5e764d9041f90bdd68213ab43614`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 867.61 ns | 801.39 ns | 0.92 | faster | 1.64 KB | 1.51 KB | 0.92 | less |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | 833.59 ns | 758.85 ns | 0.91 | faster | 1.64 KB | 1.51 KB | 0.92 | less |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.46 us | 4.35 us | 0.98 | same | 5.33 KB | 5.16 KB | 0.97 | less |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.09 us | 4.12 us | 1.01 | same | 5.33 KB | 5.16 KB | 0.97 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 893.28 ns / 1.64 KB | 866.44 ns / 1.64 KB | 867.61 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 794.09 ns / 1.51 KB | 803.39 ns / 1.51 KB | 801.39 ns / 1.51 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | base | 833.59 ns / 1.64 KB | 826.76 ns / 1.64 KB | 862.02 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | pr | 755.74 ns / 1.51 KB | 787.81 ns / 1.51 KB | 758.85 ns / 1.51 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.46 us / 5.33 KB | 4.33 us / 5.33 KB | 4.47 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 4.28 us / 5.16 KB | 4.35 us / 5.16 KB | 4.41 us / 5.16 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 4.20 us / 5.33 KB | 4.08 us / 5.33 KB | 4.09 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 4.70 us / 5.16 KB | 4.12 us / 5.16 KB | 3.99 us / 5.16 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.68 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
