### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9498ead90a5084723207ae59a7286c460ba4d052`
- Filter: `*MarshallingBenchmarks.Json_Bools`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/2 rows faster, 1/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Json_Bools | net10.0 | 1.97 us | 1.43 us | 0.73 | faster | 1.74 KB | 584 B | 0.33 | less |
| MarshallingBenchmarks.Json_Bools | net11.0 | 1.57 us | 1.27 us | 0.81 | faster | 584 B | 584 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Json_Bools | net10.0 | base | 1.97 us / 1.74 KB | 2.00 us / 1.74 KB | 1.95 us / 1.74 KB |
| MarshallingBenchmarks.Json_Bools | net10.0 | pr | 1.43 us / 584 B | 1.36 us / 584 B | 1.50 us / 584 B |
| MarshallingBenchmarks.Json_Bools | net11.0 | base | 1.57 us / 584 B | 1.54 us / 584 B | 1.57 us / 584 B |
| MarshallingBenchmarks.Json_Bools | net11.0 | pr | 1.27 us / 584 B | 1.27 us / 584 B | 1.35 us / 584 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.2 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
