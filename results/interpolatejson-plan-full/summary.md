### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f18d3c256444ff90e2cfb1c208d134ceb76d6cd1`
- Filter: `*EndpointsBenchmarks.InterpolateJson*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@47588afb2a861a099dbfa1c270fbda311984485a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/2 rows faster, 2/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | 1.46 us | 124.68 ns | 0.09 | faster | 984 B | 328 B | 0.33 | less |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | 1.39 us | 126.97 ns | 0.09 | faster | 984 B | 328 B | 0.33 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | base | 1.46 us / 984 B | 1.48 us / 984 B | 1.45 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | pr | 125.10 ns / 328 B | 121.94 ns / 328 B | 124.68 ns / 328 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | base | 1.42 us / 984 B | 1.39 us / 984 B | 1.39 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | pr | 125.07 ns / 328 B | 128.43 ns / 328 B | 126.97 ns / 328 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.12 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
