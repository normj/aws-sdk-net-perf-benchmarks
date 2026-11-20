### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `4cd86d7b75c9d6c8efac0d8795e5447b5f319141`
- Filter: `*MarshallingBenchmarks.*_*Time*s`
- Benchmark source: `aws-sdk-net-perf-benchmarks@680d5f55e04b8a0165d09100b735298d6f123287`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 4/4 rows faster, 0/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Json_DateTimeStrings | net10.0 | 15.32 us | 3.92 us | 0.26 | faster | 5.90 KB | 5.90 KB | 1.00 | same |
| MarshallingBenchmarks.Json_DateTimeStrings | net11.0 | 14.58 us | 3.63 us | 0.25 | faster | 5.90 KB | 5.90 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 23.76 us | 11.91 us | 0.50 | faster | 17.55 KB | 17.59 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | 22.89 us | 11.53 us | 0.50 | faster | 17.62 KB | 17.62 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Json_DateTimeStrings | net10.0 | base | 15.32 us / 5.90 KB | 17.13 us / 5.90 KB | 15.09 us / 5.90 KB |
| MarshallingBenchmarks.Json_DateTimeStrings | net10.0 | pr | 3.86 us / 5.90 KB | 4.06 us / 5.90 KB | 3.92 us / 5.90 KB |
| MarshallingBenchmarks.Json_DateTimeStrings | net11.0 | base | 14.25 us / 5.90 KB | 14.61 us / 5.90 KB | 14.58 us / 5.90 KB |
| MarshallingBenchmarks.Json_DateTimeStrings | net11.0 | pr | 3.57 us / 5.90 KB | 3.71 us / 5.90 KB | 3.63 us / 5.90 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 23.57 us / 17.55 KB | 23.76 us / 17.55 KB | 25.16 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 11.86 us / 17.59 KB | 12.02 us / 17.59 KB | 11.91 us / 17.59 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | base | 22.52 us / 17.62 KB | 23.50 us / 17.62 KB | 22.89 us / 17.62 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | pr | 11.53 us / 17.62 KB | 11.66 us / 17.62 KB | 11.34 us / 17.62 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.31 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.34 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
