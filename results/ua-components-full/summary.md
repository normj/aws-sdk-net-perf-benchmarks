### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `7497b8c489ad4804d48100be8b61a9e4583eee3d`
- Filter: `*RequestSetupBenchmarks.Marshaller_PreInvoke*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@949b93c3249c21567580885295d2c4d10613b8be`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/2 rows faster, 2/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.25 us | 1.10 us | 0.88 | faster | 1.84 KB | 1.73 KB | 0.94 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | 1.08 us | 1.00 us | 0.93 | same | 1.84 KB | 1.73 KB | 0.94 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.25 us / 1.84 KB | 1.25 us / 1.84 KB | 1.27 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.17 us / 1.73 KB | 1.10 us / 1.73 KB | 1.10 us / 1.73 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | base | 1.08 us / 1.84 KB | 1.08 us / 1.84 KB | 1.07 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | pr | 1.24 us / 1.73 KB | 1.00 us / 1.73 KB | 964.95 ns / 1.73 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.99 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
