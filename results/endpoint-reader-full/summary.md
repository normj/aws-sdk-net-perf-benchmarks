### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d4ad70781195d90cfab7d50ac232afc72e5d724b`
- Filter: `*EndpointsBenchmarks.Endpoint_WithAttributes*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@3da4269379c2c79cff44e45bd2afb3325f06f60d`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/2 rows faster, 2/2 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | 1.16 us | 728.29 ns | 0.63 | same | 1.27 KB | 1.20 KB | 0.94 | less |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | 1.07 us | 697.53 ns | 0.65 | faster | 1.27 KB | 1.20 KB | 0.94 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | base | 1.16 us / 1.27 KB | 1.21 us / 1.27 KB | 1.13 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | pr | 728.29 ns / 1.20 KB | 703.49 ns / 1.20 KB | 1.16 us / 1.20 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | base | 1.07 us / 1.27 KB | 1.08 us / 1.27 KB | 1.07 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | pr | 697.53 ns / 1.20 KB | 719.49 ns / 1.20 KB | 669.60 ns / 1.20 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.92 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
