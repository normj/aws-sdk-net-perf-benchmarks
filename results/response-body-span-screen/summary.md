### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `7e692221b9d3be481b39b213dce5e50bfb3c0939`
- Filter: `*MarshallingBenchmarks.Error_Json*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@dc031a7c227c8cf6d93b66123b0451aea064ea0c`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: MarshallingBenchmarks.Error_Json time, MarshallingBenchmarks.Error_Json alloc, MarshallingBenchmarks.Error_JsonNoMessage time, MarshallingBenchmarks.Error_JsonNoMessage alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Error_Json | net10.0 | 950.75 ns | 900.42 ns | 0.95 | faster | 2.28 KB | 1.86 KB | 0.82 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | 930.98 ns | 820.78 ns | 0.88 | faster | 2.38 KB | 1.91 KB | 0.80 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| MarshallingBenchmarks.Error_Json | net10.0 | base | 950.75 ns / 2.28 KB |
| MarshallingBenchmarks.Error_Json | net10.0 | pr | 900.42 ns / 1.86 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | base | 930.98 ns / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | pr | 820.78 ns / 1.91 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
