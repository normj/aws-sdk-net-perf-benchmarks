### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `daacc6328d39bbb2cca4ac24ca731f04cbfb0b01`
- Filter: `*MarshallingBenchmarks.Xml_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** regression. At least one row is slower or allocates more.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 24.11 us | 24.64 us | 1.02 | same | 17.55 KB | 17.59 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | 22.99 us | 24.32 us | 1.06 | same | 17.58 KB | 17.63 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 285.56 ns | 103.78 ns | 0.36 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | 269.81 ns | 100.44 ns | 0.37 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 71.96 us | 77.81 us | 1.08 | same | 30.40 KB | 30.40 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | 69.56 us | 76.47 us | 1.10 | **slower** | 30.39 KB | 30.45 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | 81.93 us | 86.73 us | 1.06 | **slower** | 36.63 KB | 36.64 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | 78.12 us | 85.51 us | 1.09 | **slower** | 36.60 KB | 36.57 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.54 us | 2.58 us | 1.02 | same | 14.83 KB | 12.59 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | 2.65 us | 2.57 us | 0.97 | same | 14.82 KB | 12.59 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 20.81 us | 20.83 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | 19.77 us | 19.80 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 25.65 us / 17.55 KB | 23.76 us / 17.55 KB | 24.11 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 24.64 us / 17.59 KB | 24.72 us / 17.59 KB | 24.50 us / 17.59 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | base | 24.74 us / 17.58 KB | 22.99 us / 17.58 KB | 22.76 us / 17.58 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | pr | 24.32 us / 17.63 KB | 24.01 us / 17.63 KB | 24.70 us / 17.63 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 663.70 ns / 3.48 KB | 285.56 ns / 3.48 KB | 283.87 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 99.68 ns / 296 B | 104.61 ns / 296 B | 103.78 ns / 296 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | base | 663.43 ns / 3.48 KB | 269.81 ns / 3.48 KB | 268.05 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | pr | 100.44 ns / 296 B | 99.46 ns / 296 B | 107.99 ns / 296 B |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 77.41 us / 30.40 KB | 71.79 us / 30.40 KB | 71.96 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 77.81 us / 30.40 KB | 78.75 us / 30.40 KB | 76.91 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | base | 72.77 us / 30.39 KB | 69.56 us / 30.39 KB | 69.21 us / 30.39 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | pr | 76.70 us / 30.45 KB | 76.47 us / 30.45 KB | 75.91 us / 30.45 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | base | 84.23 us / 36.63 KB | 81.93 us / 36.63 KB | 80.12 us / 36.63 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | pr | 86.73 us / 36.64 KB | 87.50 us / 36.64 KB | 85.07 us / 36.64 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | base | 81.91 us / 36.60 KB | 78.12 us / 36.60 KB | 76.98 us / 36.60 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | pr | 85.51 us / 36.57 KB | 85.83 us / 36.57 KB | 83.89 us / 36.57 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 4.37 us / 14.83 KB | 2.52 us / 14.83 KB | 2.54 us / 14.83 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.58 us / 12.59 KB | 2.61 us / 12.59 KB | 2.57 us / 12.59 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | base | 3.00 us / 14.82 KB | 2.65 us / 14.82 KB | 2.41 us / 14.82 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | pr | 2.63 us / 12.59 KB | 2.57 us / 12.59 KB | 2.45 us / 12.59 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 22.42 us / 13.55 KB | 20.78 us / 13.55 KB | 20.81 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 20.67 us / 13.55 KB | 20.83 us / 13.55 KB | 21.00 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | base | 21.25 us / 13.55 KB | 19.58 us / 13.55 KB | 19.77 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | pr | 19.82 us / 13.55 KB | 19.80 us / 13.55 KB | 19.52 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.58 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
