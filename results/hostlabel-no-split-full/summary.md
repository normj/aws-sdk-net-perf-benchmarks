### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `8be2ab2a1fbec87727389eaedb19c1dda79c8748`
- Filter: `*EndpointsBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a9b413923cd4efdbe05241eabd5cd0d22268718b`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 7/24 rows faster, 8/24 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 902.21 ns | 902.30 ns | 1.00 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | 862.97 ns | 846.69 ns | 0.98 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | 1.14 us | 1.12 us | 0.98 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | 1.48 us | 1.08 us | 0.73 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | 1.65 us | 1.61 us | 0.97 | same | 984 B | 984 B | 1.00 | same |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | 1.46 us | 1.42 us | 0.97 | same | 984 B | 984 B | 1.00 | same |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | 222.88 ns | 231.27 ns | 1.04 | same | 312 B | 312 B | 1.00 | same |
| EndpointsBenchmarks.Interpolate_Url | net11.0 | 219.74 ns | 221.29 ns | 1.01 | same | 312 B | 312 B | 1.00 | same |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | 31.09 ns | 9.62 ns | 0.31 | faster | 88 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.IsValidHostLabel_Region | net11.0 | 30.82 ns | 9.56 ns | 0.31 | faster | 88 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | 137.94 ns | 43.55 ns | 0.32 | faster | 288 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net11.0 | 147.61 ns | 43.21 ns | 0.29 | faster | 288 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | 72.45 ns | 22.59 ns | 0.31 | faster | 120 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net11.0 | 73.25 ns | 22.87 ns | 0.31 | faster | 120 B | 0 B | 0.00 | less |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | 426.83 ns | 411.61 ns | 0.96 | same | 1.06 KB | 1.06 KB | 1.00 | same |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | 410.15 ns | 383.93 ns | 0.94 | faster | 1.06 KB | 1.06 KB | 1.00 | same |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | 11.78 ns | 12.96 ns | 1.10 | same | 0 B | 0 B | 1.00 | same |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | 11.64 ns | 11.47 ns | 0.99 | same | 0 B | 0 B | 1.00 | same |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | 112.53 ns | 107.52 ns | 0.96 | same | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | 102.76 ns | 110.33 ns | 1.07 | same | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.66 us | 4.44 us | 0.95 | same | 5.33 KB | 5.12 KB | 0.96 | less |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.18 us | 4.11 us | 0.98 | same | 5.33 KB | 5.12 KB | 0.96 | less |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | 23.60 ns | 22.65 ns | 0.96 | same | 40 B | 40 B | 1.00 | same |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | 23.36 ns | 22.88 ns | 0.98 | same | 40 B | 40 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 919.78 ns / 1.64 KB | 902.21 ns / 1.64 KB | 863.87 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 915.63 ns / 1.64 KB | 902.30 ns / 1.64 KB | 851.88 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | base | 888.19 ns / 1.64 KB | 862.97 ns / 1.64 KB | 830.66 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | pr | 864.41 ns / 1.64 KB | 846.69 ns / 1.64 KB | 823.20 ns / 1.64 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | base | 1.14 us / 1.27 KB | 1.27 us / 1.27 KB | 1.13 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | pr | 1.15 us / 1.27 KB | 1.08 us / 1.27 KB | 1.12 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | base | 1.48 us / 1.27 KB | 2.00 us / 1.27 KB | 1.03 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | pr | 1.08 us / 1.27 KB | 1.51 us / 1.27 KB | 1.01 us / 1.27 KB |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | base | 1.54 us / 984 B | 1.77 us / 984 B | 1.65 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | pr | 1.61 us / 984 B | 2.37 us / 984 B | 1.47 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | base | 1.46 us / 984 B | 2.08 us / 984 B | 1.36 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | pr | 1.42 us / 984 B | 1.83 us / 984 B | 1.37 us / 984 B |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | base | 232.95 ns / 312 B | 222.61 ns / 312 B | 222.88 ns / 312 B |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | pr | 333.38 ns / 312 B | 231.27 ns / 312 B | 219.04 ns / 312 B |
| EndpointsBenchmarks.Interpolate_Url | net11.0 | base | 219.74 ns / 312 B | 222.89 ns / 312 B | 213.43 ns / 312 B |
| EndpointsBenchmarks.Interpolate_Url | net11.0 | pr | 221.29 ns / 312 B | 221.46 ns / 312 B | 214.00 ns / 312 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | base | 31.09 ns / 88 B | 44.16 ns / 88 B | 30.43 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | pr | 11.65 ns / 0 B | 9.62 ns / 0 B | 8.30 ns / 0 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net11.0 | base | 30.82 ns / 88 B | 31.18 ns / 88 B | 28.87 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net11.0 | pr | 8.44 ns / 0 B | 9.64 ns / 0 B | 9.56 ns / 0 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | base | 141.53 ns / 288 B | 137.94 ns / 288 B | 129.40 ns / 288 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | pr | 108.17 ns / 0 B | 43.55 ns / 0 B | 42.76 ns / 0 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net11.0 | base | 156.54 ns / 288 B | 147.61 ns / 288 B | 142.33 ns / 288 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net11.0 | pr | 43.64 ns / 0 B | 43.21 ns / 0 B | 39.03 ns / 0 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | base | 72.45 ns / 120 B | 85.06 ns / 120 B | 71.07 ns / 120 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | pr | 43.96 ns / 0 B | 22.59 ns / 0 B | 21.26 ns / 0 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net11.0 | base | 73.25 ns / 120 B | 73.49 ns / 120 B | 69.78 ns / 120 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net11.0 | pr | 22.87 ns / 0 B | 23.10 ns / 0 B | 22.73 ns / 0 B |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | base | 461.09 ns / 1.06 KB | 426.83 ns / 1.06 KB | 405.19 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | pr | 780.46 ns / 1.06 KB | 411.61 ns / 1.06 KB | 399.89 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | base | 410.15 ns / 1.06 KB | 432.72 ns / 1.06 KB | 394.16 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | pr | 393.31 ns / 1.06 KB | 383.93 ns / 1.06 KB | 376.92 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | base | 11.98 ns / 0 B | 11.78 ns / 0 B | 11.71 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | pr | 19.85 ns / 0 B | 12.96 ns / 0 B | 10.98 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | base | 11.25 ns / 0 B | 12.67 ns / 0 B | 11.64 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | pr | 12.66 ns / 0 B | 11.46 ns / 0 B | 11.47 ns / 0 B |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | base | 112.53 ns / 352 B | 112.70 ns / 352 B | 107.79 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | pr | 110.66 ns / 352 B | 107.52 ns / 352 B | 107.02 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | base | 102.76 ns / 352 B | 147.16 ns / 352 B | 96.56 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | pr | 100.87 ns / 352 B | 178.10 ns / 352 B | 110.33 ns / 352 B |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.66 us / 5.33 KB | 4.66 us / 5.33 KB | 4.44 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 4.58 us / 5.12 KB | 4.44 us / 5.12 KB | 4.35 us / 5.12 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 4.33 us / 5.33 KB | 4.18 us / 5.33 KB | 4.14 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 4.18 us / 5.12 KB | 4.11 us / 5.12 KB | 4.03 us / 5.12 KB |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | base | 20.02 ns / 40 B | 23.60 ns / 40 B | 25.24 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | pr | 39.34 ns / 40 B | 22.65 ns / 40 B | 22.61 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | base | 24.13 ns / 40 B | 23.36 ns / 40 B | 22.77 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | pr | 19.05 ns / 40 B | 23.78 ns / 40 B | 22.88 ns / 40 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.37 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
