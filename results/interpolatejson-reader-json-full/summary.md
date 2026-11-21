### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `801e615cfcd30c2b3295362f22f36b670773085d`
- Filter: `*EndpointsBenchmarks.InterpolateJson*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/2 rows faster, 2/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | 1.45 us | 867.38 ns | 0.60 | faster | 984 B | 368 B | 0.37 | less |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | 1.37 us | 818.64 ns | 0.60 | faster | 984 B | 368 B | 0.37 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | base | 1.45 us / 984 B | 1.46 us / 984 B | 1.45 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | pr | 859.05 ns / 368 B | 872.20 ns / 368 B | 867.38 ns / 368 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | base | 1.38 us / 984 B | 1.37 us / 984 B | 1.37 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | pr | 818.64 ns / 368 B | 823.28 ns / 368 B | 818.01 ns / 368 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.89 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
