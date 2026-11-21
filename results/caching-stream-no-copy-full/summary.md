### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d5847810ee56f4c34b0eb7fc684b520ff9dc05a2`
- Filter: `*MarshallingBenchmarks.*r*_*e*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.CachingStream_Read16K | net10.0 | 3.10 us | 2.01 us | 0.65 | faster | 44.34 KB | 28.38 KB | 0.64 | less |
| MarshallingBenchmarks.CachingStream_Read16K | net11.0 | 2.89 us | 1.95 us | 0.68 | faster | 44.34 KB | 28.38 KB | 0.64 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | 895.83 ns | 893.62 ns | 1.00 | same | 2.38 KB | 2.34 KB | 0.98 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | 869.05 ns | 849.60 ns | 0.98 | same | 2.38 KB | 2.34 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.CachingStream_Read16K | net10.0 | base | 3.13 us / 44.34 KB | 3.08 us / 44.34 KB | 3.10 us / 44.34 KB |
| MarshallingBenchmarks.CachingStream_Read16K | net10.0 | pr | 2.01 us / 28.38 KB | 1.98 us / 28.38 KB | 2.01 us / 28.38 KB |
| MarshallingBenchmarks.CachingStream_Read16K | net11.0 | base | 2.92 us / 44.34 KB | 2.86 us / 44.34 KB | 2.89 us / 44.34 KB |
| MarshallingBenchmarks.CachingStream_Read16K | net11.0 | pr | 1.95 us / 28.38 KB | 1.95 us / 28.38 KB | 1.99 us / 28.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | base | 929.70 ns / 2.38 KB | 895.83 ns / 2.38 KB | 893.08 ns / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | pr | 882.23 ns / 2.34 KB | 897.40 ns / 2.34 KB | 893.62 ns / 2.34 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | base | 870.56 ns / 2.38 KB | 868.96 ns / 2.38 KB | 869.05 ns / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | pr | 846.06 ns / 2.34 KB | 849.60 ns / 2.34 KB | 858.90 ns / 2.34 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.66 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
