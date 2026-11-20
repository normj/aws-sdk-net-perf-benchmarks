### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `8be2ab2a1fbec87727389eaedb19c1dda79c8748`
- Filter: `*EndpointsBenchmarks.IsV*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a9b413923cd4efdbe05241eabd5cd0d22268718b`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: EndpointsBenchmarks.IsValidHostLabel_Region time, EndpointsBenchmarks.IsValidHostLabel_Region alloc, EndpointsBenchmarks.IsValidHostLabel_SubDomains time, EndpointsBenchmarks.IsValidHostLabel_SubDomains alloc, EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots time, EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | 30.76 ns | 9.70 ns | 0.32 | faster | 88 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | 156.68 ns | 43.07 ns | 0.27 | faster | 288 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | 73.79 ns | 21.69 ns | 0.29 | faster | 120 B | 0 B | 0.00 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | base | 30.76 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | pr | 9.70 ns / 0 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | base | 156.68 ns / 288 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | pr | 43.07 ns / 0 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | base | 73.79 ns / 120 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | pr | 21.69 ns / 0 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.01 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
