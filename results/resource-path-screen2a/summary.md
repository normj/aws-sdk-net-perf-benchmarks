### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d5e9c7f38fba06a17b258aabb5278fb8976f3edb`
- Filter: `*SigningBenchmarks.*Res*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@737cb3b9091357f499c6b92d8dcd19c5df003035`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: SigningBenchmarks.CanonicalizeResourcePath_RestJson time, SigningBenchmarks.CanonicalizeResourcePath_RestJson alloc, SigningBenchmarks.CanonicalizeResourcePath_S3Key time, SigningBenchmarks.CanonicalizeResourcePath_S3Key alloc, SigningBenchmarks.Presign_S3GetObject time, SigningBenchmarks.Presign_S3GetObject alloc, SigningBenchmarks.Sign_RestJsonPathResources time, SigningBenchmarks.Sign_RestJsonPathResources alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | 678.04 ns | 316.39 ns | 0.47 | faster | 1.27 KB | 376 B | 0.29 | less |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | 611.48 ns | 291.96 ns | 0.48 | faster | 1.19 KB | 200 B | 0.16 | less |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.57 us | 6.05 us | 0.92 | faster | 7.16 KB | 6.52 KB | 0.91 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 7.36 us | 6.32 us | 0.86 | faster | 5.40 KB | 4.49 KB | 0.83 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | base | 678.04 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | pr | 316.39 ns / 376 B |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | base | 611.48 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | pr | 291.96 ns / 200 B |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.57 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.05 us / 6.52 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 7.36 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.32 us / 4.49 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
