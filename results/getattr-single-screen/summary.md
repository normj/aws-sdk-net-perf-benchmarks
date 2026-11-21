### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `a9f0d91da8dc13e22ec39d864103c84e9301eec6`
- Filter: `*EndpointsBenchmarks.GetAttr*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3da4269379c2c79cff44e45bd2afb3325f06f60d`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: EndpointsBenchmarks.GetAttr_Indexed time, EndpointsBenchmarks.GetAttr_SingleSegment time, EndpointsBenchmarks.GetAttr_SingleSegment alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.GetAttr_Indexed | net10.0 | 48.80 ns | 41.91 ns | 0.86 | faster | 48 B | 48 B | 1.00 | same |
| EndpointsBenchmarks.GetAttr_SingleSegment | net10.0 | 29.69 ns | 15.80 ns | 0.53 | faster | 32 B | 0 B | 0.00 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| EndpointsBenchmarks.GetAttr_Indexed | net10.0 | base | 48.80 ns / 48 B |
| EndpointsBenchmarks.GetAttr_Indexed | net10.0 | pr | 41.91 ns / 48 B |
| EndpointsBenchmarks.GetAttr_SingleSegment | net10.0 | base | 29.69 ns / 32 B |
| EndpointsBenchmarks.GetAttr_SingleSegment | net10.0 | pr | 15.80 ns / 0 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
