### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `8687b43f20b4a053732a7af0eb372966f946f73b`
- Filter: `*MarshallingBenchmarks.Json_DateTimeEpoch`
- Benchmark source: `aws-sdk-net-perf-benchmarks@dc031a7c227c8cf6d93b66123b0451aea064ea0c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/2 rows faster, 0/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Json_DateTimeEpoch | net10.0 | 6.00 us | 3.78 us | 0.63 | faster | 1.41 KB | 1.41 KB | 1.00 | same |
| MarshallingBenchmarks.Json_DateTimeEpoch | net11.0 | 6.24 us | 3.74 us | 0.60 | faster | 1.41 KB | 1.41 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| MarshallingBenchmarks.Json_DateTimeEpoch | net10.0 | base | 6.01 us / 1.41 KB | 6.00 us / 1.41 KB | 5.69 us / 1.41 KB |
| MarshallingBenchmarks.Json_DateTimeEpoch | net10.0 | pr | 3.84 us / 1.41 KB | 3.78 us / 1.41 KB | 3.75 us / 1.41 KB |
| MarshallingBenchmarks.Json_DateTimeEpoch | net11.0 | base | 6.27 us / 1.41 KB | 6.24 us / 1.41 KB | 6.06 us / 1.41 KB |
| MarshallingBenchmarks.Json_DateTimeEpoch | net11.0 | pr | 4.13 us / 1.41 KB | 3.67 us / 1.41 KB | 3.74 us / 1.41 KB |

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
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.99 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
