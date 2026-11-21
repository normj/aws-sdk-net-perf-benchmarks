### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d4ad70781195d90cfab7d50ac232afc72e5d724b`
- Filter: `*EndpointsBenchmarks.*Resolve*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3da4269379c2c79cff44e45bd2afb3325f06f60d`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 901.49 ns | 857.71 ns | 0.95 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | 830.28 ns | 833.42 ns | 1.00 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.42 us | 4.03 us | 0.91 | faster | 5.33 KB | 5.26 KB | 0.99 | less |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.08 us | 3.81 us | 0.93 | faster | 5.33 KB | 5.26 KB | 0.99 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 901.49 ns / 1.64 KB | 1.02 us / 1.64 KB | 864.75 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 861.57 ns / 1.64 KB | 857.71 ns / 1.64 KB | 849.10 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | base | 836.49 ns / 1.64 KB | 820.99 ns / 1.64 KB | 830.28 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | pr | 825.52 ns / 1.64 KB | 833.42 ns / 1.64 KB | 841.81 ns / 1.64 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.69 us / 5.33 KB | 4.37 us / 5.33 KB | 4.42 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 4.04 us / 5.26 KB | 4.03 us / 5.26 KB | 4.03 us / 5.26 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 4.10 us / 5.33 KB | 4.06 us / 5.33 KB | 4.08 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 3.80 us / 5.26 KB | 3.81 us / 5.26 KB | 3.81 us / 5.26 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
