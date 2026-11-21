### BenchmarkDotNet A/B results

- Base: `e8787bdc93722861856c927c505fd2aa89b8fcf8`
- PR: `66aa9098f6111c6358307440ca683525a5b39f0a`
- Filter: `*EndpointsBenchmarks.InterpolateJson*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@47588afb2a861a099dbfa1c270fbda311984485a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** no measurable change: below the 5% time bar and no allocation reduction.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | 124.52 ns | 120.78 ns | 0.97 | same | 328 B | 328 B | 1.00 | same |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | 126.01 ns | 122.86 ns | 0.98 | same | 328 B | 328 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | base | 123.30 ns / 328 B | 124.77 ns / 328 B | 124.52 ns / 328 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | pr | 123.60 ns / 328 B | 120.78 ns / 328 B | 119.95 ns / 328 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | base | 126.69 ns / 328 B | 124.22 ns / 328 B | 126.01 ns / 328 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | pr | 124.58 ns / 328 B | 122.86 ns / 328 B | 119.81 ns / 328 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
