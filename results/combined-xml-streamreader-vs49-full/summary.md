### BenchmarkDotNet A/B results

- Base: `766014b8720fdcaf75be9eb36a885ab93be79865`
- PR: `563b9b0077db95a05eb498afc04c9c11095199ac`
- Filter: `*MarshallingBenchmarks.Xml_*Response*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/4 rows faster, 2/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 76.52 ns | 78.05 ns | 1.02 | same | 296 B | 296 B | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | 76.68 ns | 76.03 ns | 0.99 | same | 296 B | 296 B | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.56 us | 2.51 us | 0.98 | same | 14.82 KB | 12.66 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | 2.45 us | 2.35 us | 0.96 | same | 14.87 KB | 12.59 KB | 0.85 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 75.45 ns / 296 B | 76.52 ns / 296 B | 78.45 ns / 296 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 77.77 ns / 296 B | 80.77 ns / 296 B | 78.05 ns / 296 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | base | 73.15 ns / 296 B | 81.02 ns / 296 B | 76.68 ns / 296 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | pr | 73.71 ns / 296 B | 76.03 ns / 296 B | 76.25 ns / 296 B |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.51 us / 14.82 KB | 2.74 us / 14.82 KB | 2.56 us / 14.82 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.60 us / 12.66 KB | 2.43 us / 12.66 KB | 2.51 us / 12.66 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | base | 2.34 us / 14.87 KB | 2.57 us / 14.87 KB | 2.45 us / 14.87 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | pr | 2.45 us / 12.59 KB | 2.35 us / 12.59 KB | 2.34 us / 12.59 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.02 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.1 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
