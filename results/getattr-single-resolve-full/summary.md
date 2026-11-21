### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `a9f0d91da8dc13e22ec39d864103c84e9301eec6`
- Filter: `*EndpointsBenchmarks.*Resolve*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3da4269379c2c79cff44e45bd2afb3325f06f60d`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 927.71 ns | 849.76 ns | 0.92 | faster | 1.64 KB | 1.61 KB | 0.98 | less |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | 864.51 ns | 845.56 ns | 0.98 | same | 1.64 KB | 1.61 KB | 0.98 | less |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.51 us | 4.39 us | 0.97 | same | 5.33 KB | 5.33 KB | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.30 us | 4.38 us | 1.02 | same | 5.33 KB | 5.33 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 883.44 ns / 1.64 KB | 994.75 ns / 1.64 KB | 927.71 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 858.86 ns / 1.61 KB | 849.76 ns / 1.61 KB | 841.56 ns / 1.61 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | base | 864.51 ns / 1.64 KB | 840.34 ns / 1.64 KB | 1.13 us / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | pr | 845.56 ns / 1.61 KB | 822.02 ns / 1.61 KB | 902.65 ns / 1.61 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.45 us / 5.33 KB | 4.60 us / 5.33 KB | 4.51 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 4.43 us / 5.33 KB | 4.39 us / 5.33 KB | 4.37 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 4.23 us / 5.33 KB | 4.30 us / 5.33 KB | 5.64 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 4.25 us / 5.33 KB | 4.38 us / 5.33 KB | 4.40 us / 5.33 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.55 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
