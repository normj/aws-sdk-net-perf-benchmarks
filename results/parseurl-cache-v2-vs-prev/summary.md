### BenchmarkDotNet A/B results

- Base: `c20c7a78147093f4c500780d955c80a95d16a4ca`
- PR: `6d87c6d5002c701e21140b420d161f801b9b661f`
- Filter: `*EndpointsBenchmarks.ParseURL*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@2035ceb1abcc5e764d9041f90bdd68213ab43614`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/4 rows faster, 0/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | 93.04 ns | 90.84 ns | 0.98 | same | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | 79.62 ns | 74.38 ns | 0.93 | same | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | 89.65 ns | 87.94 ns | 0.98 | same | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | 75.03 ns | 68.94 ns | 0.92 | faster | 352 B | 352 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | base | 88.96 ns / 352 B | 94.94 ns / 352 B | 93.04 ns / 352 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | pr | 91.61 ns / 352 B | 90.84 ns / 352 B | 89.95 ns / 352 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | base | 76.63 ns / 352 B | 79.62 ns / 352 B | 102.10 ns / 352 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | pr | 81.75 ns / 352 B | 74.38 ns / 352 B | 73.39 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | base | 85.55 ns / 352 B | 92.00 ns / 352 B | 89.65 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | pr | 87.94 ns / 352 B | 93.17 ns / 352 B | 84.93 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | base | 74.72 ns / 352 B | 75.03 ns / 352 B | 95.25 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | pr | 68.27 ns / 352 B | 68.94 ns / 352 B | 71.26 ns / 352 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.67 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
