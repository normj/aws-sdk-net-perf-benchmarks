### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `bb97473ffb0d79f1c3bb7d033a2de323fe8b0989`
- Filter: `*MarshallingBenchmarks.Xml_*Response*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@006442ff2f72f983cd8c053d7b4aed995c40aeae`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 291.40 ns | 77.28 ns | 0.27 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | 263.59 ns | 73.01 ns | 0.28 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.63 us | 2.56 us | 0.97 | same | 14.78 KB | 14.82 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | 2.39 us | 2.47 us | 1.03 | same | 14.85 KB | 14.87 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 330.58 ns / 3.48 KB | 291.40 ns / 3.48 KB | 264.91 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 77.41 ns / 296 B | 77.28 ns / 296 B | 73.86 ns / 296 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | base | 262.19 ns / 3.48 KB | 269.43 ns / 3.48 KB | 263.59 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | pr | 73.01 ns / 296 B | 74.54 ns / 296 B | 71.26 ns / 296 B |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.78 us / 14.78 KB | 2.63 us / 14.78 KB | 2.54 us / 14.78 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.84 us / 14.82 KB | 2.56 us / 14.82 KB | 2.47 us / 14.82 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | base | 2.39 us / 14.85 KB | 2.47 us / 14.85 KB | 2.34 us / 14.85 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | pr | 2.47 us / 14.87 KB | 3.35 us / 14.87 KB | 2.36 us / 14.87 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.57 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
