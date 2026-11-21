### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `801e615cfcd30c2b3295362f22f36b670773085d`
- Filter: `*EndpointsBenchmarks.*Resolve*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: EndpointsBenchmarks.S3_Resolve time, EndpointsBenchmarks.S3_Resolve alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 941.07 ns | 924.89 ns | 0.98 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.50 us | 4.15 us | 0.92 | faster | 5.33 KB | 4.73 KB | 0.89 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 941.07 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 924.89 ns / 1.64 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.50 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 4.15 us / 4.73 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
