### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `4cd86d7b75c9d6c8efac0d8795e5447b5f319141`
- Filter: `*MarshallingBenchmarks.*_*i*s*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@e5c05117c2da534b174b1c1ff91428da3bd5b653`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: MarshallingBenchmarks.Format_ISO8601 time, MarshallingBenchmarks.Json_DateTimeStrings time, MarshallingBenchmarks.Xml_DateTimes time, MarshallingBenchmarks.Xml_ListObjectsLike time.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | 156.12 ns | 147.98 ns | 0.95 | faster | 72 B | 72 B | 1.00 | same |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | 81.24 ns | 79.12 ns | 0.97 | same | 64 B | 64 B | 1.00 | same |
| MarshallingBenchmarks.Json_DateTimeStrings | net10.0 | 16.65 us | 4.37 us | 0.26 | faster | 5.90 KB | 5.90 KB | 1.00 | same |
| MarshallingBenchmarks.Json_Strings | net10.0 | 3.74 us | 3.67 us | 0.98 | same | 7.66 KB | 7.66 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | 25.58 us | 12.68 us | 0.50 | faster | 17.55 KB | 17.59 KB | 1.00 | same |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | 77.46 us | 61.09 us | 0.79 | faster | 30.40 KB | 30.40 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | base | 156.12 ns / 72 B |
| MarshallingBenchmarks.Format_ISO8601 | net10.0 | pr | 147.98 ns / 72 B |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | base | 81.24 ns / 64 B |
| MarshallingBenchmarks.Format_ISO8601NoMs | net10.0 | pr | 79.12 ns / 64 B |
| MarshallingBenchmarks.Json_DateTimeStrings | net10.0 | base | 16.65 us / 5.90 KB |
| MarshallingBenchmarks.Json_DateTimeStrings | net10.0 | pr | 4.37 us / 5.90 KB |
| MarshallingBenchmarks.Json_Strings | net10.0 | base | 3.74 us / 7.66 KB |
| MarshallingBenchmarks.Json_Strings | net10.0 | pr | 3.67 us / 7.66 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | base | 25.58 us / 17.55 KB |
| MarshallingBenchmarks.Xml_DateTimes | net10.0 | pr | 12.68 us / 17.59 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | base | 77.46 us / 30.40 KB |
| MarshallingBenchmarks.Xml_ListObjectsLike | net10.0 | pr | 61.09 us / 30.40 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
