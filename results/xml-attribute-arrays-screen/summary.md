### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `c96f06806deeb916c0844b1afa25e29bee167b1d`
- Filter: `*MarshallingBenchmarks.Xml_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@f409e49348979763e5397865bb3a8571df03a4fa`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: MarshallingBenchmarks.Xml_SmallResponse alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 23.76 us | 23.85 us | 1.00 | same | 17.55 KB | 17.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 275.33 ns | 287.60 ns | 1.04 | same | 3.48 KB | 3.48 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 73.82 us | 70.79 us | 0.96 | same | 30.40 KB | 30.18 KB | 0.99 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | 81.05 us | 79.14 us | 0.98 | same | 36.63 KB | 36.41 KB | 0.99 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.51 us | 2.47 us | 0.98 | same | 14.83 KB | 14.60 KB | 0.98 | less |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 20.87 us | 20.95 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 23.76 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 23.85 us / 17.55 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 275.33 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 287.60 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 73.82 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 70.79 us / 30.18 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | base | 81.05 us / 36.63 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | pr | 79.14 us / 36.41 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.51 us / 14.83 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.47 us / 14.60 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 20.87 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 20.95 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
