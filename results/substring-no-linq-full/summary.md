### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `431971032f0a6e2fc46f5ac4c0277b6ab9ea56cf`
- Filter: `*EndpointsBenchmarks.S*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a9b413923cd4efdbe05241eabd5cd0d22268718b`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 0/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.46 us | 4.37 us | 0.98 | same | 5.33 KB | 5.33 KB | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.08 us | 4.14 us | 1.01 | same | 5.33 KB | 5.33 KB | 1.00 | same |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | 18.37 ns | 8.04 ns | 0.44 | faster | 40 B | 40 B | 1.00 | same |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | 22.76 ns | 7.64 ns | 0.34 | faster | 40 B | 40 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.51 us / 5.33 KB | 4.46 us / 5.33 KB | 4.41 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 4.33 us / 5.33 KB | 4.37 us / 5.33 KB | 4.48 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 4.08 us / 5.33 KB | 4.08 us / 5.33 KB | 4.15 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 4.06 us / 5.33 KB | 4.14 us / 5.33 KB | 4.52 us / 5.33 KB |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | base | 18.37 ns / 40 B | 18.20 ns / 40 B | 23.57 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | pr | 8.00 ns / 40 B | 8.04 ns / 40 B | 8.35 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | base | 22.15 ns / 40 B | 22.76 ns / 40 B | 23.52 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | pr | 7.64 ns / 40 B | 7.63 ns / 40 B | 8.31 ns / 40 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
