### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `f5d7f350292eef7c99f0ef206df0c529115aa65e`
- Filter: `*EndpointsBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a9b413923cd4efdbe05241eabd5cd0d22268718b`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 5/24 rows faster, 2/24 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | 861.46 ns | 849.51 ns | 0.99 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | 831.71 ns | 811.48 ns | 0.98 | same | 1.64 KB | 1.64 KB | 1.00 | same |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | 1.10 us | 1.10 us | 1.00 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | 1.04 us | 1.07 us | 1.03 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | 1.50 us | 1.46 us | 0.98 | same | 984 B | 984 B | 1.00 | same |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | 1.40 us | 1.37 us | 0.97 | same | 984 B | 984 B | 1.00 | same |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | 215.09 ns | 215.40 ns | 1.00 | same | 312 B | 312 B | 1.00 | same |
| EndpointsBenchmarks.Interpolate_Url | net11.0 | 215.29 ns | 212.28 ns | 0.99 | same | 312 B | 312 B | 1.00 | same |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | 29.95 ns | 29.53 ns | 0.99 | same | 88 B | 88 B | 1.00 | same |
| EndpointsBenchmarks.IsValidHostLabel_Region | net11.0 | 29.06 ns | 28.81 ns | 0.99 | same | 88 B | 88 B | 1.00 | same |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | 126.64 ns | 127.62 ns | 1.01 | same | 288 B | 288 B | 1.00 | same |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net11.0 | 151.50 ns | 142.36 ns | 0.94 | same | 288 B | 288 B | 1.00 | same |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | 68.50 ns | 68.48 ns | 1.00 | same | 120 B | 120 B | 1.00 | same |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net11.0 | 69.28 ns | 67.89 ns | 0.98 | same | 120 B | 120 B | 1.00 | same |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | 408.21 ns | 322.71 ns | 0.79 | faster | 1.06 KB | 880 B | 0.81 | less |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | 396.36 ns | 308.17 ns | 0.78 | faster | 1.06 KB | 880 B | 0.81 | less |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | 11.21 ns | 3.33 ns | 0.30 | faster | 0 B | 0 B | 1.00 | same |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | 10.80 ns | 3.09 ns | 0.29 | faster | 0 B | 0 B | 1.00 | same |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | 111.93 ns | 104.08 ns | 0.93 | same | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | 96.64 ns | 98.89 ns | 1.02 | same | 352 B | 352 B | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net10.0 | 4.50 us | 4.37 us | 0.97 | same | 5.33 KB | 5.33 KB | 1.00 | same |
| EndpointsBenchmarks.S3_Resolve | net11.0 | 4.23 us | 4.12 us | 0.97 | same | 5.33 KB | 5.33 KB | 1.00 | same |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | 21.92 ns | 18.34 ns | 0.84 | faster | 40 B | 40 B | 1.00 | same |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | 22.88 ns | 22.05 ns | 0.96 | same | 40 B | 40 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | base | 931.14 ns / 1.64 KB | 860.80 ns / 1.64 KB | 861.46 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net10.0 | pr | 849.51 ns / 1.64 KB | 848.02 ns / 1.64 KB | 858.08 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | base | 830.16 ns / 1.64 KB | 831.71 ns / 1.64 KB | 835.92 ns / 1.64 KB |
| EndpointsBenchmarks.DynamoDB_Resolve | net11.0 | pr | 958.61 ns / 1.64 KB | 811.48 ns / 1.64 KB | 808.43 ns / 1.64 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | base | 1.11 us / 1.27 KB | 1.10 us / 1.27 KB | 1.10 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net10.0 | pr | 1.10 us / 1.27 KB | 1.11 us / 1.27 KB | 1.09 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | base | 1.05 us / 1.27 KB | 1.03 us / 1.27 KB | 1.04 us / 1.27 KB |
| EndpointsBenchmarks.Endpoint_WithAttributes | net11.0 | pr | 1.09 us / 1.27 KB | 1.07 us / 1.27 KB | 1.03 us / 1.27 KB |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | base | 1.50 us / 984 B | 1.53 us / 984 B | 1.46 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net10.0 | pr | 1.48 us / 984 B | 1.46 us / 984 B | 1.46 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | base | 1.40 us / 984 B | 1.36 us / 984 B | 1.42 us / 984 B |
| EndpointsBenchmarks.InterpolateJson_AuthSchemes | net11.0 | pr | 1.40 us / 984 B | 1.37 us / 984 B | 1.37 us / 984 B |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | base | 214.36 ns / 312 B | 224.29 ns / 312 B | 215.09 ns / 312 B |
| EndpointsBenchmarks.Interpolate_Url | net10.0 | pr | 215.40 ns / 312 B | 216.42 ns / 312 B | 215.35 ns / 312 B |
| EndpointsBenchmarks.Interpolate_Url | net11.0 | base | 215.29 ns / 312 B | 243.80 ns / 312 B | 214.27 ns / 312 B |
| EndpointsBenchmarks.Interpolate_Url | net11.0 | pr | 218.81 ns / 312 B | 211.96 ns / 312 B | 212.28 ns / 312 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | base | 29.95 ns / 88 B | 33.78 ns / 88 B | 29.33 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net10.0 | pr | 29.28 ns / 88 B | 29.56 ns / 88 B | 29.53 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net11.0 | base | 30.66 ns / 88 B | 28.81 ns / 88 B | 29.06 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_Region | net11.0 | pr | 28.53 ns / 88 B | 29.92 ns / 88 B | 28.81 ns / 88 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | base | 123.83 ns / 288 B | 129.05 ns / 288 B | 126.64 ns / 288 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net10.0 | pr | 126.37 ns / 288 B | 127.62 ns / 288 B | 131.01 ns / 288 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net11.0 | base | 151.50 ns / 288 B | 138.65 ns / 288 B | 157.17 ns / 288 B |
| EndpointsBenchmarks.IsValidHostLabel_SubDomains | net11.0 | pr | 138.34 ns / 288 B | 142.36 ns / 288 B | 156.09 ns / 288 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | base | 68.94 ns / 120 B | 68.50 ns / 120 B | 67.11 ns / 120 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net10.0 | pr | 68.48 ns / 120 B | 68.39 ns / 120 B | 69.43 ns / 120 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net11.0 | base | 70.93 ns / 120 B | 69.28 ns / 120 B | 68.19 ns / 120 B |
| EndpointsBenchmarks.IsVirtualHostableS3Bucket_NoDots | net11.0 | pr | 67.89 ns / 120 B | 72.43 ns / 120 B | 66.27 ns / 120 B |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | base | 408.21 ns / 1.06 KB | 400.35 ns / 1.06 KB | 441.46 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net10.0 | pr | 328.37 ns / 880 B | 322.71 ns / 880 B | 320.39 ns / 880 B |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | base | 397.74 ns / 1.06 KB | 390.83 ns / 1.06 KB | 396.36 ns / 1.06 KB |
| EndpointsBenchmarks.ParseArn_AccessPoint | net11.0 | pr | 310.38 ns / 880 B | 307.68 ns / 880 B | 308.17 ns / 880 B |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | base | 11.14 ns / 0 B | 11.21 ns / 0 B | 11.32 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net10.0 | pr | 3.33 ns / 0 B | 3.05 ns / 0 B | 3.58 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | base | 11.68 ns / 0 B | 10.80 ns / 0 B | 10.79 ns / 0 B |
| EndpointsBenchmarks.ParseArn_NotArn | net11.0 | pr | 3.09 ns / 0 B | 3.35 ns / 0 B | 2.82 ns / 0 B |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | base | 111.93 ns / 352 B | 119.52 ns / 352 B | 106.03 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net10.0 | pr | 109.24 ns / 352 B | 103.58 ns / 352 B | 104.08 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | base | 96.80 ns / 352 B | 96.64 ns / 352 B | 95.70 ns / 352 B |
| EndpointsBenchmarks.Partition_KnownRegion | net11.0 | pr | 115.73 ns / 352 B | 96.99 ns / 352 B | 98.89 ns / 352 B |
| EndpointsBenchmarks.S3_Resolve | net10.0 | base | 4.65 us / 5.33 KB | 4.50 us / 5.33 KB | 4.43 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net10.0 | pr | 4.35 us / 5.33 KB | 4.43 us / 5.33 KB | 4.37 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | base | 4.83 us / 5.33 KB | 4.11 us / 5.33 KB | 4.23 us / 5.33 KB |
| EndpointsBenchmarks.S3_Resolve | net11.0 | pr | 4.19 us / 5.33 KB | 4.10 us / 5.33 KB | 4.12 us / 5.33 KB |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | base | 21.92 ns / 40 B | 22.90 ns / 40 B | 21.90 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net10.0 | pr | 21.87 ns / 40 B | 18.34 ns / 40 B | 17.99 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | base | 24.02 ns / 40 B | 22.87 ns / 40 B | 22.88 ns / 40 B |
| EndpointsBenchmarks.Substring_Suffix | net11.0 | pr | 22.12 ns / 40 B | 21.96 ns / 40 B | 22.05 ns / 40 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
