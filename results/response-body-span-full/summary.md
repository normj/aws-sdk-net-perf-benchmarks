### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `7e692221b9d3be481b39b213dce5e50bfb3c0939`
- Filter: `*MarshallingBenchmarks.Error_Json*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@dc031a7c227c8cf6d93b66123b0451aea064ea0c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Error_Json | net10.0 | 1.05 us | 915.06 ns | 0.87 | faster | 2.28 KB | 1.86 KB | 0.82 | less |
| MarshallingBenchmarks.Error_Json | net11.0 | 933.32 ns | 913.19 ns | 0.98 | same | 2.28 KB | 1.86 KB | 0.82 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | 1.04 us | 867.41 ns | 0.83 | faster | 2.38 KB | 1.91 KB | 0.80 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | 888.34 ns | 854.14 ns | 0.96 | same | 2.38 KB | 1.91 KB | 0.80 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Error_Json | net10.0 | base | 1.05 us / 2.28 KB | 993.06 ns / 2.28 KB | 1.18 us / 2.28 KB |
| MarshallingBenchmarks.Error_Json | net10.0 | pr | 901.38 ns / 1.86 KB | 915.06 ns / 1.86 KB | 959.47 ns / 1.86 KB |
| MarshallingBenchmarks.Error_Json | net11.0 | base | 910.52 ns / 2.28 KB | 933.32 ns / 2.28 KB | 965.09 ns / 2.28 KB |
| MarshallingBenchmarks.Error_Json | net11.0 | pr | 848.92 ns / 1.86 KB | 913.19 ns / 1.86 KB | 923.62 ns / 1.86 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | base | 1.04 us / 2.38 KB | 974.07 ns / 2.38 KB | 1.05 us / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | pr | 867.41 ns / 1.91 KB | 859.27 ns / 1.91 KB | 887.29 ns / 1.91 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | base | 887.06 ns / 2.38 KB | 888.34 ns / 2.38 KB | 944.68 ns / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | pr | 800.82 ns / 1.91 KB | 854.14 ns / 1.91 KB | 864.16 ns / 1.91 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.8 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
