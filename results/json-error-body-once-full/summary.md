### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `40433098199f7510934cf16e0ee8a54adb3092c6`
- Filter: `*MarshallingBenchmarks.Error_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 3/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Error_Json | net10.0 | 1.01 us | 919.92 ns | 0.91 | same | 2.28 KB | 1.48 KB | 0.65 | less |
| MarshallingBenchmarks.Error_Json | net11.0 | 982.38 ns | 846.29 ns | 0.86 | faster | 2.28 KB | 1.48 KB | 0.65 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | 963.84 ns | 739.16 ns | 0.77 | faster | 2.38 KB | 1.41 KB | 0.59 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | 956.80 ns | 712.82 ns | 0.75 | faster | 2.38 KB | 1.41 KB | 0.59 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Error_Json | net10.0 | base | 1.01 us / 2.28 KB | 1.01 us / 2.28 KB | 979.36 ns / 2.28 KB |
| MarshallingBenchmarks.Error_Json | net10.0 | pr | 919.92 ns / 1.48 KB | 1.00 us / 1.48 KB | 827.15 ns / 1.48 KB |
| MarshallingBenchmarks.Error_Json | net11.0 | base | 982.38 ns / 2.28 KB | 989.45 ns / 2.28 KB | 976.34 ns / 2.28 KB |
| MarshallingBenchmarks.Error_Json | net11.0 | pr | 858.41 ns / 1.48 KB | 846.29 ns / 1.48 KB | 786.32 ns / 1.48 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | base | 958.81 ns / 2.38 KB | 973.25 ns / 2.38 KB | 963.84 ns / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | pr | 811.83 ns / 1.41 KB | 739.16 ns / 1.41 KB | 705.32 ns / 1.41 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | base | 948.31 ns / 2.38 KB | 956.80 ns / 2.38 KB | 1.29 us / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net11.0 | pr | 739.31 ns / 1.41 KB | 712.82 ns / 1.41 KB | 695.95 ns / 1.41 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
