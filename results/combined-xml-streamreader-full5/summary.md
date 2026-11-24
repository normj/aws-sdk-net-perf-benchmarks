### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `563b9b0077db95a05eb498afc04c9c11095199ac`
- Filter: `*MarshallingBenchmarks.Xml_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.4 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/12 rows faster, 4/12 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 23.88 us | 23.47 us | 0.98 | same | 17.55 KB | 17.56 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | 23.01 us | 23.04 us | 1.00 | same | 17.58 KB | 17.60 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 288.78 ns | 89.82 ns | 0.31 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | 275.70 ns | 91.46 ns | 0.33 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 71.91 us | 71.27 us | 0.99 | same | 30.40 KB | 30.37 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | 69.90 us | 69.66 us | 1.00 | same | 30.39 KB | 30.41 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | 80.27 us | 80.31 us | 1.00 | same | 36.63 KB | 36.64 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | 77.48 us | 78.26 us | 1.01 | same | 36.60 KB | 36.60 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.55 us | 2.43 us | 0.96 | same | 14.83 KB | 12.66 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | 2.44 us | 2.33 us | 0.95 | same | 14.82 KB | 12.66 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 20.95 us | 20.85 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | 19.67 us | 19.93 us | 1.01 | same | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 23.88 us / 17.55 KB | 23.86 us / 17.55 KB | 23.88 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 23.41 us / 17.56 KB | 23.57 us / 17.56 KB | 23.47 us / 17.56 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | base | 22.87 us / 17.58 KB | 23.01 us / 17.58 KB | 23.96 us / 17.58 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | pr | 23.04 us / 17.60 KB | 22.94 us / 17.60 KB | 23.87 us / 17.60 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 274.10 ns / 3.48 KB | 288.78 ns / 3.48 KB | 301.87 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 89.82 ns / 296 B | 91.98 ns / 296 B | 88.76 ns / 296 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | base | 282.50 ns / 3.48 KB | 275.70 ns / 3.48 KB | 268.81 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | pr | 92.44 ns / 296 B | 91.46 ns / 296 B | 91.32 ns / 296 B |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 72.72 us / 30.40 KB | 71.91 us / 30.40 KB | 71.59 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 71.27 us / 30.37 KB | 71.10 us / 30.37 KB | 71.78 us / 30.37 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | base | 68.54 us / 30.39 KB | 69.90 us / 30.39 KB | 69.93 us / 30.39 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | pr | 69.17 us / 30.41 KB | 69.66 us / 30.41 KB | 70.82 us / 30.41 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | base | 81.39 us / 36.63 KB | 80.04 us / 36.63 KB | 80.27 us / 36.63 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | pr | 80.20 us / 36.64 KB | 80.31 us / 36.64 KB | 80.50 us / 36.64 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | base | 76.30 us / 36.60 KB | 77.48 us / 36.60 KB | 78.99 us / 36.60 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | pr | 78.26 us / 36.60 KB | 78.08 us / 36.60 KB | 79.14 us / 36.60 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.50 us / 14.83 KB | 2.59 us / 14.83 KB | 2.55 us / 14.83 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.45 us / 12.66 KB | 2.43 us / 12.66 KB | 2.39 us / 12.66 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | base | 2.40 us / 14.82 KB | 2.44 us / 14.82 KB | 2.69 us / 14.82 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | pr | 2.33 us / 12.66 KB | 2.34 us / 12.66 KB | 2.33 us / 12.66 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 20.75 us / 13.55 KB | 21.04 us / 13.55 KB | 20.95 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 20.70 us / 13.55 KB | 21.30 us / 13.55 KB | 20.85 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | base | 19.56 us / 13.55 KB | 19.67 us / 13.55 KB | 20.41 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | pr | 19.68 us / 13.55 KB | 19.93 us / 13.55 KB | 20.17 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
