### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `6d87c6d5002c701e21140b420d161f801b9b661f`
- Filter: `*EndpointsBenchmarks.ParseURL*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@2035ceb1abcc5e764d9041f90bdd68213ab43614`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 4/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | 716.95 ns | 90.13 ns | 0.13 | faster | 984 B | 352 B | 0.36 | less |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | 590.67 ns | 72.03 ns | 0.12 | faster | 984 B | 352 B | 0.36 | less |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | 666.56 ns | 85.03 ns | 0.13 | faster | 968 B | 352 B | 0.36 | less |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | 589.33 ns | 66.98 ns | 0.11 | faster | 968 B | 352 B | 0.36 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | base | 725.58 ns / 984 B | 716.45 ns / 984 B | 716.95 ns / 984 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | pr | 90.13 ns / 352 B | 91.33 ns / 352 B | 89.30 ns / 352 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | base | 590.67 ns / 984 B | 590.87 ns / 984 B | 588.05 ns / 984 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net11.0 | pr | 72.03 ns / 352 B | 71.60 ns / 352 B | 79.02 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | base | 664.44 ns / 968 B | 670.79 ns / 968 B | 666.56 ns / 968 B |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | pr | 86.02 ns / 352 B | 84.82 ns / 352 B | 85.03 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | base | 586.00 ns / 968 B | 589.33 ns / 968 B | 590.00 ns / 968 B |
| EndpointsBenchmarks.ParseURL_WithPath | net11.0 | pr | 66.84 ns / 352 B | 66.98 ns / 352 B | 67.35 ns / 352 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.32 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
