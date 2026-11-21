### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f02057dd4816993122aa0895d1099bb172ea0b9c`
- Filter: `*EndpointsBenchmarks.*Endpoint_WithAttributes*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@47588afb2a861a099dbfa1c270fbda311984485a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/2 rows faster, 2/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | 1.11 us | 230.83 ns | 0.21 | faster | 1.27 KB | 696 B | 0.54 | less |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | 1.05 us | 207.62 ns | 0.20 | faster | 1.27 KB | 696 B | 0.54 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | base | 1.16 us / 1.27 KB | 1.11 us / 1.27 KB | 1.09 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | pr | 240.26 ns / 696 B | 230.83 ns / 696 B | 215.70 ns / 696 B |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | base | 1.09 us / 1.27 KB | 1.05 us / 1.27 KB | 1.03 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | pr | 237.56 ns / 696 B | 207.62 ns / 696 B | 203.77 ns / 696 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
