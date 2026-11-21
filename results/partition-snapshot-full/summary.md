### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `0a4dca0d0b9b701b4e6e13b164a3bdc3ce64fa9c`
- Filter: `*EndpointsBenchmarks.Partition_KnownRegion*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@dc031a7c227c8cf6d93b66123b0451aea064ea0c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/2 rows faster, 0/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | 107.56 ns | 80.47 ns | 0.75 | faster | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | 105.89 ns | 68.19 ns | 0.64 | faster | 352 B | 352 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | base | 107.35 ns / 352 B | 107.56 ns / 352 B | 111.82 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | pr | 80.34 ns / 352 B | 80.47 ns / 352 B | 81.69 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | base | 101.90 ns / 352 B | 106.92 ns / 352 B | 105.89 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | pr | 68.19 ns / 352 B | 68.49 ns / 352 B | 67.86 ns / 352 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.41 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
