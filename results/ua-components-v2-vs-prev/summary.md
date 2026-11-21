### BenchmarkDotNet A/B results

- Base: `b496276f5843049fe58bfd3499b4f421974912de`
- PR: `65eb36eedafe75bfee1f3036e5d832f2e065e158`
- Filter: `*RequestSetupBenchmarks.Marshaller_PreInvoke*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** no measurable change: below the 5% time bar and no allocation reduction.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.12 us | 1.10 us | 0.98 | same | 1.73 KB | 1.73 KB | 1.00 | same |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | 938.66 ns | 940.87 ns | 1.00 | same | 1.73 KB | 1.73 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.17 us / 1.73 KB | 1.12 us / 1.73 KB | 1.10 us / 1.73 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.10 us / 1.73 KB | 1.09 us / 1.73 KB | 1.12 us / 1.73 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | base | 947.78 ns / 1.73 KB | 930.15 ns / 1.73 KB | 938.66 ns / 1.73 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | pr | 940.87 ns / 1.73 KB | 924.79 ns / 1.73 KB | 996.29 ns / 1.73 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.9 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
