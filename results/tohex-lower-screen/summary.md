### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `be31be44580436df759d61335631c2455e35e669`
- Filter: `*SigningBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@b72f09ef00248c55da8131f7b440f4c8383f018a`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | 759.53 ns | 715.76 ns | 0.94 | faster | 1.27 KB | 1.27 KB | 1.00 | same |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | 730.86 ns | 654.84 ns | 0.90 | faster | 1.19 KB | 1.19 KB | 1.00 | same |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.80 us | 6.46 us | 0.95 | same | 7.16 KB | 7.16 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.22 us | 8.31 us | 1.33 | **slower** | 4.29 KB | 4.29 KB | 1.00 | same |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.75 us | 6.72 us | 1.00 | same | 5.40 KB | 5.40 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.53 us | 5.41 us | 0.98 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.76 us | 8.13 us | 1.41 | **slower** | 4.51 KB | 4.51 KB | 1.00 | same |
| SigningBenchmarks.ToHex_Sha256Lower | net10.0 | 49.83 ns | 22.43 ns | 0.45 | faster | 152 B | 152 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | base | 759.53 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | pr | 715.76 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | base | 730.86 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | pr | 654.84 ns / 1.19 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.80 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.46 us / 7.16 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.22 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 8.31 us / 4.29 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.75 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.72 us / 5.40 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.53 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.41 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.76 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 8.13 us / 4.51 KB |
| SigningBenchmarks.ToHex_Sha256Lower | net10.0 | base | 49.83 ns / 152 B |
| SigningBenchmarks.ToHex_Sha256Lower | net10.0 | pr | 22.43 ns / 152 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
