### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `801e615cfcd30c2b3295362f22f36b670773085d`
- Filter: `*EndpointsBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@949b93c3249c21567580885295d2c4d10613b8be`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 887.31 ns | 867.40 ns | 0.98 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | 1.08 us | 1.09 us | 1.01 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | 1.46 us | 865.79 ns | 0.59 | faster | 984 B | 368 B | 0.37 | less |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | 215.18 ns | 218.09 ns | 1.01 | same | 312 B | 312 B | 1.00 | same |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | 29.39 ns | 29.45 ns | 1.00 | same | 88 B | 88 B | 1.00 | same |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | 125.18 ns | 127.64 ns | 1.02 | same | 288 B | 288 B | 1.00 | same |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | 68.57 ns | 69.00 ns | 1.01 | same | 120 B | 120 B | 1.00 | same |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | 410.20 ns | 400.25 ns | 0.98 | same | 1.06 KB | 1.06 KB | 1.00 | same |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | 11.18 ns | 10.99 ns | 0.98 | same | 0 B | 0 B | 1.00 | same |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | 109.42 ns | 131.45 ns | 1.20 | **slower** | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.91 us | 3.82 us | 0.78 | faster | 5.33 KB | 4.73 KB | 0.89 | less |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | 18.05 ns | 22.05 ns | 1.22 | **slower** | 40 B | 40 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 887.31 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 867.40 ns / 1.64 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | base | 1.08 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | pr | 1.09 us / 1.27 KB |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | base | 1.46 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | pr | 865.79 ns / 368 B |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | base | 215.18 ns / 312 B |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | pr | 218.09 ns / 312 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | base | 29.39 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | pr | 29.45 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | base | 125.18 ns / 288 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | pr | 127.64 ns / 288 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | base | 68.57 ns / 120 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | pr | 69.00 ns / 120 B |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | base | 410.20 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | pr | 400.25 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | base | 11.18 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | pr | 10.99 ns / 0 B |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | base | 109.42 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | pr | 131.45 ns / 352 B |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.91 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 3.82 us / 4.73 KB |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | base | 18.05 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | pr | 22.05 ns / 40 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
