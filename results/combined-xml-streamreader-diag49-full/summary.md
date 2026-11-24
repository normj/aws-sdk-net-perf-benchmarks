### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `766014b8720fdcaf75be9eb36a885ab93be79865`
- Filter: `*MarshallingBenchmarks.Xml_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/12 rows faster, 2/12 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 23.56 us | 23.51 us | 1.00 | same | 17.55 KB | 17.59 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | 22.61 us | 23.18 us | 1.03 | same | 17.58 KB | 17.57 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 277.12 ns | 89.05 ns | 0.32 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | 268.01 ns | 87.55 ns | 0.33 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 71.73 us | 70.79 us | 0.99 | same | 30.40 KB | 30.44 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | 70.33 us | 69.49 us | 0.99 | same | 30.39 KB | 30.38 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | 80.19 us | 79.93 us | 1.00 | same | 36.63 KB | 36.64 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | 79.18 us | 78.37 us | 0.99 | same | 36.60 KB | 36.57 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.49 us | 2.53 us | 1.02 | same | 14.83 KB | 14.87 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | 2.41 us | 2.41 us | 1.00 | same | 14.82 KB | 14.80 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 20.78 us | 20.84 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | 19.75 us | 19.73 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 23.68 us / 17.55 KB | 23.49 us / 17.55 KB | 23.56 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 23.40 us / 17.59 KB | 23.51 us / 17.59 KB | 23.52 us / 17.59 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | base | 24.45 us / 17.58 KB | 22.59 us / 17.58 KB | 22.61 us / 17.58 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | pr | 22.97 us / 17.57 KB | 23.20 us / 17.57 KB | 23.18 us / 17.57 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 277.12 ns / 3.48 KB | 270.92 ns / 3.48 KB | 277.53 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 89.05 ns / 296 B | 97.47 ns / 296 B | 87.32 ns / 296 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | base | 263.15 ns / 3.48 KB | 268.01 ns / 3.48 KB | 270.42 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | pr | 84.92 ns / 296 B | 87.91 ns / 296 B | 87.55 ns / 296 B |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 72.59 us / 30.40 KB | 71.73 us / 30.40 KB | 71.68 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 70.35 us / 30.44 KB | 70.79 us / 30.44 KB | 71.00 us / 30.44 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | base | 70.33 us / 30.39 KB | 69.61 us / 30.39 KB | 70.56 us / 30.39 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | pr | 69.73 us / 30.38 KB | 69.46 us / 30.38 KB | 69.49 us / 30.38 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | base | 82.17 us / 36.63 KB | 80.12 us / 36.63 KB | 80.19 us / 36.63 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | pr | 79.61 us / 36.64 KB | 79.93 us / 36.64 KB | 80.17 us / 36.64 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | base | 79.62 us / 36.60 KB | 79.18 us / 36.60 KB | 77.87 us / 36.60 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | pr | 78.64 us / 36.57 KB | 78.37 us / 36.57 KB | 77.38 us / 36.57 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.53 us / 14.83 KB | 2.49 us / 14.83 KB | 2.48 us / 14.83 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.51 us / 14.87 KB | 2.54 us / 14.87 KB | 2.53 us / 14.87 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | base | 2.41 us / 14.82 KB | 2.38 us / 14.82 KB | 2.44 us / 14.82 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | pr | 2.41 us / 14.80 KB | 2.41 us / 14.80 KB | 2.45 us / 14.80 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 20.78 us / 13.55 KB | 20.74 us / 13.55 KB | 20.81 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 20.84 us / 13.55 KB | 20.72 us / 13.55 KB | 20.96 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | base | 19.48 us / 13.55 KB | 19.75 us / 13.55 KB | 19.93 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | pr | 19.85 us / 13.55 KB | 19.73 us / 13.55 KB | 19.60 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.12 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.04 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
