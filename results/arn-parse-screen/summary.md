### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f5d7f350292eef7c99f0ef206df0c529115aa65e`
- Filter: `*EndpointsBenchmarks.ParseArn*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a9b413923cd4efdbe05241eabd5cd0d22268718b`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: EndpointsBenchmarks.ParseArn_AccessPoint time, EndpointsBenchmarks.ParseArn_AccessPoint alloc, EndpointsBenchmarks.ParseArn_NotArn time, EndpointsBenchmarks.ParseArn_NotArn alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | 406.18 ns | 344.47 ns | 0.85 | faster | 1.06 KB | 880 B | 0.81 | less |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | 12.89 ns | 3.14 ns | 0.24 | faster | 0 B | 0 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | base | 406.18 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | pr | 344.47 ns / 880 B |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | base | 12.89 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | pr | 3.14 ns / 0 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
