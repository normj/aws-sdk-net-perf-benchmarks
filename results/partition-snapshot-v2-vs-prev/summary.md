### BenchmarkDotNet A/B results

- Base: `ef76dbbc6f3b9f892d56c57e8dda134d898dc9dd`
- PR: `e02a990daaf607745ea27be3105203a21a7ab9d4`
- Filter: `*EndpointsBenchmarks.Partition_KnownRegion*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@2035ceb1abcc5e764d9041f90bdd68213ab43614`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** no measurable change: below the 5% time bar and no allocation reduction.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | 84.50 ns | 87.36 ns | 1.03 | same | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | 73.98 ns | 76.09 ns | 1.03 | same | 352 B | 352 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | base | 84.50 ns / 352 B | 82.70 ns / 352 B | 93.49 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | pr | 88.52 ns / 352 B | 86.64 ns / 352 B | 87.36 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | base | 73.98 ns / 352 B | 72.63 ns / 352 B | 118.03 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | pr | 74.55 ns / 352 B | 76.09 ns / 352 B | 77.15 ns / 352 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.23 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.43GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.1 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
