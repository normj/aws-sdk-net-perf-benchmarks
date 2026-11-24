### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `22c2e963908598a2d28c46c9c343b814b2f27bbc`
- Filter: `*MarshallingBenchmarks.Xml_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 3/12 rows faster, 4/12 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 23.52 us | 23.37 us | 0.99 | same | 17.55 KB | 17.56 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | 22.90 us | 22.99 us | 1.00 | same | 17.58 KB | 17.60 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 287.08 ns | 104.24 ns | 0.36 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | 269.59 ns | 100.11 ns | 0.37 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 71.42 us | 71.34 us | 1.00 | same | 30.40 KB | 30.37 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | 70.03 us | 69.86 us | 1.00 | same | 30.39 KB | 30.41 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | 80.03 us | 80.79 us | 1.01 | same | 36.63 KB | 36.64 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | 77.99 us | 78.60 us | 1.01 | same | 36.60 KB | 36.60 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.53 us | 2.45 us | 0.97 | same | 14.83 KB | 12.66 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | 2.48 us | 2.34 us | 0.94 | faster | 14.82 KB | 12.66 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 20.81 us | 20.84 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | 19.83 us | 19.71 us | 0.99 | same | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 23.52 us / 17.55 KB | 23.56 us / 17.55 KB | 23.47 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 23.37 us / 17.56 KB | 23.35 us / 17.56 KB | 23.59 us / 17.56 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | base | 22.90 us / 17.58 KB | 22.91 us / 17.58 KB | 22.69 us / 17.58 KB |
| MarshallingBenchmarks.Xml_DateTimes | net11.0 | pr | 22.91 us / 17.60 KB | 23.02 us / 17.60 KB | 22.99 us / 17.60 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 287.08 ns / 3.48 KB | 286.79 ns / 3.48 KB | 300.23 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 104.24 ns / 296 B | 109.74 ns / 296 B | 104.02 ns / 296 B |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | base | 276.50 ns / 3.48 KB | 269.59 ns / 3.48 KB | 266.00 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net11.0 | pr | 98.75 ns / 296 B | 100.73 ns / 296 B | 100.11 ns / 296 B |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 71.34 us / 30.40 KB | 71.42 us / 30.40 KB | 71.59 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 71.36 us / 30.37 KB | 71.32 us / 30.37 KB | 71.34 us / 30.37 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | base | 71.18 us / 30.39 KB | 68.16 us / 30.39 KB | 70.03 us / 30.39 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net11.0 | pr | 69.52 us / 30.41 KB | 69.86 us / 30.41 KB | 70.43 us / 30.41 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | base | 79.68 us / 36.63 KB | 80.03 us / 36.63 KB | 80.05 us / 36.63 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | pr | 80.79 us / 36.64 KB | 81.00 us / 36.64 KB | 80.47 us / 36.64 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | base | 78.42 us / 36.60 KB | 76.80 us / 36.60 KB | 77.99 us / 36.60 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net11.0 | pr | 77.80 us / 36.60 KB | 78.60 us / 36.60 KB | 78.67 us / 36.60 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.54 us / 14.83 KB | 2.52 us / 14.83 KB | 2.53 us / 14.83 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.39 us / 12.66 KB | 2.45 us / 12.66 KB | 2.54 us / 12.66 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | base | 2.64 us / 14.82 KB | 2.48 us / 14.82 KB | 2.42 us / 14.82 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net11.0 | pr | 2.38 us / 12.66 KB | 2.33 us / 12.66 KB | 2.34 us / 12.66 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 20.77 us / 13.55 KB | 20.81 us / 13.55 KB | 20.83 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 20.84 us / 13.55 KB | 20.87 us / 13.55 KB | 20.84 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | base | 20.18 us / 13.55 KB | 19.79 us / 13.55 KB | 19.83 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net11.0 | pr | 19.71 us / 13.55 KB | 20.00 us / 13.55 KB | 19.63 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
