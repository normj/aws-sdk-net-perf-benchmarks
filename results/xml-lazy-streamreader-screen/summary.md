### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `bb97473ffb0d79f1c3bb7d033a2de323fe8b0989`
- Filter: `*MarshallingBenchmarks.Xml_*Response*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@006442ff2f72f983cd8c053d7b4aed995c40aeae`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: MarshallingBenchmarks.Xml_HeaderOnlyResponse time, MarshallingBenchmarks.Xml_HeaderOnlyResponse alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | 272.52 ns | 76.22 ns | 0.28 | faster | 3.48 KB | 296 B | 0.08 | less |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | 2.47 us | 2.51 us | 1.01 | same | 14.78 KB | 14.82 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | base | 272.52 ns / 3.48 KB |
| MarshallingBenchmarks.Xml_HeaderOnlyResponse | net10.0 | pr | 76.22 ns / 296 B |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | base | 2.47 us / 14.78 KB |
| MarshallingBenchmarks.Xml_SmallResponse | net10.0 | pr | 2.51 us / 14.82 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
