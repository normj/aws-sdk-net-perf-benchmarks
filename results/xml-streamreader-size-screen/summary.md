### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `bfbb8bcafdcd8cdd584dcc3506e37b12760bc177`
- Filter: `*MarshallingBenchmarks.Xml_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@f409e49348979763e5397865bb3a8571df03a4fa`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: MarshallingBenchmarks.Xml_HeaderOnlyResponse time, MarshallingBenchmarks.Xml_HeaderOnlyResponse alloc, MarshallingBenchmarks.Xml_SmallResponse alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 23.80 us | 24.03 us | 1.01 | same | 17.55 KB | 17.55 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 274.68 ns | 165.52 ns | 0.60 | faster | 3.48 KB | 880 B | 0.25 | less |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 71.87 us | 72.01 us | 1.00 | same | 30.40 KB | 30.40 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | 82.44 us | 80.65 us | 0.98 | same | 36.63 KB | 36.63 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.52 us | 2.44 us | 0.97 | same | 14.83 KB | 12.64 KB | 0.85 | less |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | 20.90 us | 20.93 us | 1.00 | same | 13.55 KB | 13.55 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 23.80 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 24.03 us / 17.55 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 274.68 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 165.52 ns / 880 B |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 71.87 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 72.01 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | base | 82.44 us / 36.63 KB |
| MarshallingBenchmarks.Xml_ListObjectsStructures | net10.0 | pr | 80.65 us / 36.63 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.52 us / 14.83 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.44 us / 12.64 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | base | 20.90 us / 13.55 KB |
| MarshallingBenchmarks.Xml_WriteRequestBody | net10.0 | pr | 20.93 us / 13.55 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.62 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
