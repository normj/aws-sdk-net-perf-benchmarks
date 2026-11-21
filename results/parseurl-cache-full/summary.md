### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `47b79b920eac4b98662e3f7eb03251d1850e4230`
- Filter: `*EndpointsBenchmarks.ParseURL*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@2035ceb1abcc5e764d9041f90bdd68213ab43614`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 4/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | 750.35 ns | 93.41 ns | 0.12 | faster | 984 B | 352 B | 0.36 | less |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | 618.93 ns | 76.93 ns | 0.12 | faster | 984 B | 352 B | 0.36 | less |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | 723.73 ns | 90.08 ns | 0.12 | faster | 968 B | 352 B | 0.36 | less |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | 620.51 ns | 72.15 ns | 0.12 | faster | 968 B | 352 B | 0.36 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | base | 769.98 ns / 984 B | 750.35 ns / 984 B | 720.95 ns / 984 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | pr | 96.09 ns / 352 B | 93.41 ns / 352 B | 92.67 ns / 352 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | base | 618.93 ns / 984 B | 611.58 ns / 984 B | 683.31 ns / 984 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | pr | 74.70 ns / 352 B | 76.93 ns / 352 B | 81.18 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | base | 701.74 ns / 968 B | 723.73 ns / 968 B | 994.16 ns / 968 B |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | pr | 91.29 ns / 352 B | 88.23 ns / 352 B | 90.08 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | base | 610.63 ns / 968 B | 620.51 ns / 968 B | 681.80 ns / 968 B |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | pr | 72.15 ns / 352 B | 72.97 ns / 352 B | 69.12 ns / 352 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.41 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
