### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `c96f06806deeb916c0844b1afa25e29bee167b1d`
- Filter: `*MarshallingBenchmarks.Xml_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@f409e49348979763e5397865bb3a8571df03a4fa`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/12 rows faster, 2/12 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 23.59 us | 23.89 us | 1.01 | same | 17.55 KB | 17.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | 22.76 us | 23.05 us | 1.01 | same | 17.58 KB | 17.58 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 285.27 ns | 286.02 ns | 1.00 | same | 3.48 KB | 3.48 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | 265.25 ns | 273.55 ns | 1.03 | same | 3.48 KB | 3.48 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 71.72 us | 71.52 us | 1.00 | same | 30.40 KB | 30.18 KB | 0.99 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | 69.40 us | 69.32 us | 1.00 | same | 30.39 KB | 30.17 KB | 0.99 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | 79.60 us | 79.57 us | 1.00 | same | 36.63 KB | 36.41 KB | 0.99 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | 77.45 us | 77.25 us | 1.00 | same | 36.60 KB | 36.37 KB | 0.99 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.49 us | 2.44 us | 0.98 | same | 14.83 KB | 14.60 KB | 0.98 | less |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | 2.48 us | 2.34 us | 0.94 | faster | 14.82 KB | 14.60 KB | 0.98 | less |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 20.80 us | 20.74 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | 19.57 us | 19.68 us | 1.01 | same | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 24.14 us / 17.55 KB | 23.51 us / 17.55 KB | 23.59 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 23.89 us / 17.55 KB | 23.87 us / 17.55 KB | 23.97 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | base | 22.77 us / 17.58 KB | 22.76 us / 17.58 KB | 22.60 us / 17.58 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | pr | 22.98 us / 17.58 KB | 23.26 us / 17.58 KB | 23.05 us / 17.58 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 374.50 ns / 3.48 KB | 285.27 ns / 3.48 KB | 277.85 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 286.14 ns / 3.48 KB | 270.11 ns / 3.48 KB | 286.02 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | base | 308.05 ns / 3.48 KB | 264.77 ns / 3.48 KB | 265.25 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | pr | 276.56 ns / 3.48 KB | 272.30 ns / 3.48 KB | 273.55 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 71.75 us / 30.40 KB | 71.72 us / 30.40 KB | 71.39 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 73.13 us / 30.18 KB | 70.96 us / 30.18 KB | 71.52 us / 30.18 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | base | 69.40 us / 30.39 KB | 68.98 us / 30.39 KB | 69.47 us / 30.39 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | pr | 70.48 us / 30.17 KB | 69.23 us / 30.17 KB | 69.32 us / 30.17 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | base | 80.52 us / 36.63 KB | 79.60 us / 36.63 KB | 79.41 us / 36.63 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | pr | 79.99 us / 36.41 KB | 79.06 us / 36.41 KB | 79.57 us / 36.41 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | base | 77.81 us / 36.60 KB | 76.54 us / 36.60 KB | 77.45 us / 36.60 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | pr | 76.90 us / 36.37 KB | 77.58 us / 36.37 KB | 77.25 us / 36.37 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.71 us / 14.83 KB | 2.49 us / 14.83 KB | 2.46 us / 14.83 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.44 us / 14.60 KB | 2.44 us / 14.60 KB | 2.46 us / 14.60 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | base | 2.78 us / 14.82 KB | 2.48 us / 14.82 KB | 2.40 us / 14.82 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | pr | 2.31 us / 14.60 KB | 2.36 us / 14.60 KB | 2.34 us / 14.60 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 21.88 us / 13.55 KB | 20.80 us / 13.55 KB | 20.67 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 20.74 us / 13.55 KB | 20.72 us / 13.55 KB | 20.90 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | base | 20.14 us / 13.55 KB | 19.57 us / 13.55 KB | 19.57 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | pr | 19.68 us / 13.55 KB | 19.72 us / 13.55 KB | 19.55 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
