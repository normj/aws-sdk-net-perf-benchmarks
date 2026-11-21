### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `40433098199f7510934cf16e0ee8a54adb3092c6`
- Filter: `*MarshallingBenchmarks.Error_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@949b93c3249c21567580885295d2c4d10613b8be`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: MarshallingBenchmarks.Error_Json time, MarshallingBenchmarks.Error_Json alloc, MarshallingBenchmarks.Error_JsonNoMessage time, MarshallingBenchmarks.Error_JsonNoMessage alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| MarshallingBenchmarks.Error_Json | net10.0 | 1.01 us | 831.19 ns | 0.82 | faster | 2.28 KB | 1.48 KB | 0.65 | less |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | 905.54 ns | 710.25 ns | 0.78 | faster | 2.38 KB | 1.41 KB | 0.59 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| MarshallingBenchmarks.Error_Json | net10.0 | base | 1.01 us / 2.28 KB |
| MarshallingBenchmarks.Error_Json | net10.0 | pr | 831.19 ns / 1.48 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | base | 905.54 ns / 2.38 KB |
| MarshallingBenchmarks.Error_JsonNoMessage | net10.0 | pr | 710.25 ns / 1.41 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
