### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `47b79b920eac4b98662e3f7eb03251d1850e4230`
- Filter: `*EndpointsBenchmarks.ParseURL*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@2035ceb1abcc5e764d9041f90bdd68213ab43614`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: EndpointsBenchmarks.ParseURL_CustomEndpoint time, EndpointsBenchmarks.ParseURL_CustomEndpoint alloc, EndpointsBenchmarks.ParseURL_WithPath time, EndpointsBenchmarks.ParseURL_WithPath alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | 727.15 ns | 89.54 ns | 0.12 | faster | 984 B | 352 B | 0.36 | less |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | 665.44 ns | 84.95 ns | 0.13 | faster | 968 B | 352 B | 0.36 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | base | 727.15 ns / 984 B |
| EndpointsBenchmarks.ParseURL_CustomEndpoint | net10.0 | pr | 89.54 ns / 352 B |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | base | 665.44 ns / 968 B |
| EndpointsBenchmarks.ParseURL_WithPath | net10.0 | pr | 84.95 ns / 352 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.27 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
