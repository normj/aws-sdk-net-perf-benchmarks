### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f4c2f05b664dc49e0bb7ba597d8bd10f956591a3`
- Filter: `*MarshallingBenchmarks.Json_StructureMembers`
- Benchmark source: `aws-sdk-net-perf-benchmarks@dc031a7c227c8cf6d93b66123b0451aea064ea0c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/2 rows faster, 0/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Json_StructureMembers | net10.0 | 67.48 us | 62.77 us | 0.93 | faster | 32.66 KB | 32.66 KB | 1.00 | same |
| MarshallingBenchmarks.Json_StructureMembers | net11.0 | 65.50 us | 57.77 us | 0.88 | faster | 32.66 KB | 32.66 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Json_StructureMembers | net10.0 | base | 67.48 us / 32.66 KB | 67.54 us / 32.66 KB | 66.92 us / 32.66 KB |
| MarshallingBenchmarks.Json_StructureMembers | net10.0 | pr | 62.77 us / 32.66 KB | 62.86 us / 32.66 KB | 60.96 us / 32.66 KB |
| MarshallingBenchmarks.Json_StructureMembers | net11.0 | base | 65.89 us / 32.66 KB | 65.50 us / 32.66 KB | 62.68 us / 32.66 KB |
| MarshallingBenchmarks.Json_StructureMembers | net11.0 | pr | 59.02 us / 32.66 KB | 57.72 us / 32.66 KB | 57.77 us / 32.66 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.15 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
