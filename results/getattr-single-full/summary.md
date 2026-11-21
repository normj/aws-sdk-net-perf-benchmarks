### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `a9f0d91da8dc13e22ec39d864103c84e9301eec6`
- Filter: `*EndpointsBenchmarks.GetAttr*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3da4269379c2c79cff44e45bd2afb3325f06f60d`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 4/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.GetAttr_Indexed | net10.0 | 48.32 ns | 44.14 ns | 0.91 | faster | 48 B | 48 B | 1.00 | same |
| EndpointsBenchmarks.GetAttr_Indexed | net11.0 | 49.21 ns | 42.35 ns | 0.86 | faster | 48 B | 48 B | 1.00 | same |
| EndpointsBenchmarks.GetAttr_SingleSegment | net10.0 | 31.16 ns | 16.88 ns | 0.54 | faster | 32 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.GetAttr_SingleSegment | net11.0 | 29.76 ns | 14.39 ns | 0.48 | faster | 32 B | 0 B | 0.00 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.GetAttr_Indexed | net10.0 | base | 51.84 ns / 48 B | 48.32 ns / 48 B | 47.63 ns / 48 B |
| EndpointsBenchmarks.GetAttr_Indexed | net10.0 | pr | 44.33 ns / 48 B | 44.14 ns / 48 B | 41.24 ns / 48 B |
| EndpointsBenchmarks.GetAttr_Indexed | net11.0 | base | 48.16 ns / 48 B | 49.21 ns / 48 B | 50.83 ns / 48 B |
| EndpointsBenchmarks.GetAttr_Indexed | net11.0 | pr | 43.20 ns / 48 B | 42.35 ns / 48 B | 40.16 ns / 48 B |
| EndpointsBenchmarks.GetAttr_SingleSegment | net10.0 | base | 31.16 ns / 32 B | 31.37 ns / 32 B | 30.67 ns / 32 B |
| EndpointsBenchmarks.GetAttr_SingleSegment | net10.0 | pr | 16.88 ns / 0 B | 17.12 ns / 0 B | 16.08 ns / 0 B |
| EndpointsBenchmarks.GetAttr_SingleSegment | net11.0 | base | 31.48 ns / 32 B | 29.76 ns / 32 B | 28.53 ns / 32 B |
| EndpointsBenchmarks.GetAttr_SingleSegment | net11.0 | pr | 14.51 ns / 0 B | 14.39 ns / 0 B | 13.99 ns / 0 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.47 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.41 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
