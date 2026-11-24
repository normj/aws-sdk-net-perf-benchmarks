### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `c3ae51538a2d452df87e1c411ad6bf7a6275d666`
- Filter: `*MarshallingBenchmarks.Xml_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/12 rows faster, 4/12 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 23.58 us | 23.46 us | 1.00 | same | 17.55 KB | 17.57 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | 22.81 us | 23.11 us | 1.01 | same | 17.58 KB | 17.61 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 283.12 ns | 92.76 ns | 0.33 | faster | 3.48 KB | 304 B | 0.09 | less |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | 268.84 ns | 92.35 ns | 0.34 | faster | 3.48 KB | 304 B | 0.09 | less |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 71.78 us | 71.06 us | 0.99 | same | 30.40 KB | 30.38 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | 68.56 us | 69.96 us | 1.02 | same | 30.39 KB | 30.42 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | 79.77 us | 80.03 us | 1.00 | same | 36.63 KB | 36.65 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | 76.88 us | 78.54 us | 1.02 | same | 36.60 KB | 36.61 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.51 us | 2.43 us | 0.97 | same | 14.83 KB | 12.66 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | 2.39 us | 2.34 us | 0.98 | same | 14.82 KB | 12.66 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 20.66 us | 20.84 us | 1.01 | same | 13.55 KB | 13.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | 19.68 us | 19.71 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 23.58 us / 17.55 KB | 23.52 us / 17.55 KB | 23.63 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 23.51 us / 17.57 KB | 23.22 us / 17.57 KB | 23.46 us / 17.57 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | base | 22.88 us / 17.58 KB | 22.77 us / 17.58 KB | 22.81 us / 17.58 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | pr | 22.68 us / 17.61 KB | 23.27 us / 17.61 KB | 23.11 us / 17.61 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 283.12 ns / 3.48 KB | 285.19 ns / 3.48 KB | 279.05 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 92.76 ns / 304 B | 94.12 ns / 304 B | 88.29 ns / 304 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | base | 268.84 ns / 3.48 KB | 259.52 ns / 3.48 KB | 272.50 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | pr | 88.81 ns / 304 B | 92.35 ns / 304 B | 93.65 ns / 304 B |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 71.68 us / 30.40 KB | 71.78 us / 30.40 KB | 71.78 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 71.06 us / 30.38 KB | 70.51 us / 30.38 KB | 71.22 us / 30.38 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | base | 69.09 us / 30.39 KB | 68.43 us / 30.39 KB | 68.56 us / 30.39 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | pr | 68.94 us / 30.42 KB | 69.96 us / 30.42 KB | 70.52 us / 30.42 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | base | 80.36 us / 36.63 KB | 79.74 us / 36.63 KB | 79.77 us / 36.63 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | pr | 79.95 us / 36.65 KB | 80.03 us / 36.65 KB | 81.11 us / 36.65 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | base | 76.88 us / 36.60 KB | 76.78 us / 36.60 KB | 77.86 us / 36.60 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | pr | 78.54 us / 36.61 KB | 78.20 us / 36.61 KB | 78.69 us / 36.61 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.49 us / 14.83 KB | 2.51 us / 14.83 KB | 2.55 us / 14.83 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.43 us / 12.66 KB | 2.39 us / 12.66 KB | 2.46 us / 12.66 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | base | 2.39 us / 14.82 KB | 2.35 us / 14.82 KB | 2.45 us / 14.82 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | pr | 2.31 us / 12.66 KB | 2.36 us / 12.66 KB | 2.34 us / 12.66 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 20.77 us / 13.55 KB | 20.66 us / 13.55 KB | 20.65 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 20.73 us / 13.55 KB | 20.84 us / 13.55 KB | 20.88 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | base | 20.02 us / 13.55 KB | 19.58 us / 13.55 KB | 19.68 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | pr | 19.71 us / 13.55 KB | 19.52 us / 13.55 KB | 19.76 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.63 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
