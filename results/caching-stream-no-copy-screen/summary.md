### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d5847810ee56f4c34b0eb7fc684b520ff9dc05a2`
- Filter: `*MarshallingBenchmarks.*r*_*e*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: MarshallingBenchmarks.CachingStream_Read16K time, MarshallingBenchmarks.CachingStream_Read16K alloc, MarshallingBenchmarks.Error_JsonNoMessage alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.CachingStream_Read16K | net10.0 | 3.17 us | 2.27 us | 0.72 | faster | 44.34 KB | 28.38 KB | 0.64 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | 1.02 us | 993.20 ns | 0.98 | same | 2.38 KB | 2.34 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| MarshallingBenchmarks.CachingStream_Read16K | net10.0 | base | 3.17 us / 44.34 KB |
| MarshallingBenchmarks.CachingStream_Read16K | net10.0 | pr | 2.27 us / 28.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | base | 1.02 us / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | pr | 993.20 ns / 2.34 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
