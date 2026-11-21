### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d734d67b18eb1e71140794d02f203fc8e4dff57f`
- Filter: `*MarshallingBenchmarks.Xml_WriteRequestBody*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@356dda9754aff5bec8e170106465576d7073449a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/2 rows faster, 0/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 21.17 us | 13.22 us | 0.62 | faster | 13.55 KB | 13.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | 20.11 us | 12.95 us | 0.64 | faster | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 21.30 us / 13.55 KB | 21.09 us / 13.55 KB | 21.17 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 13.22 us / 13.55 KB | 13.30 us / 13.55 KB | 13.14 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | base | 20.11 us / 13.55 KB | 19.77 us / 13.55 KB | 20.24 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | pr | 12.95 us / 13.55 KB | 12.95 us / 13.55 KB | 12.86 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.05 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.31 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
