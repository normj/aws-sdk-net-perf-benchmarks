### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d5e9c7f38fba06a17b258aabb5278fb8976f3edb`
- Filter: `*SigningBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@737cb3b9091357f499c6b92d8dcd19c5df003035`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 8/14 rows faster, 10/14 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | 930.43 ns | 342.45 ns | 0.37 | faster | 1.27 KB | 376 B | 0.29 | less |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | 682.25 ns | 323.71 ns | 0.47 | faster | 1.27 KB | 376 B | 0.29 | less |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | 881.85 ns | 299.81 ns | 0.34 | faster | 1.19 KB | 200 B | 0.16 | less |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | 606.51 ns | 296.32 ns | 0.49 | faster | 1.19 KB | 200 B | 0.16 | less |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.78 us | 6.39 us | 0.94 | same | 7.16 KB | 6.52 KB | 0.91 | less |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.50 us | 6.30 us | 0.97 | same | 7.16 KB | 6.52 KB | 0.91 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.18 us | 6.25 us | 1.01 | same | 4.29 KB | 4.29 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.03 us | 6.03 us | 1.00 | same | 4.29 KB | 4.29 KB | 1.00 | same |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 7.23 us | 6.35 us | 0.88 | faster | 5.40 KB | 4.49 KB | 0.83 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.63 us | 6.24 us | 0.94 | faster | 5.40 KB | 4.49 KB | 0.83 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.77 us | 4.95 us | 0.86 | faster | 4.44 KB | 3.45 KB | 0.78 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.37 us | 5.01 us | 0.93 | faster | 4.44 KB | 3.45 KB | 0.78 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.85 us | 5.68 us | 0.97 | same | 4.51 KB | 4.51 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.57 us | 5.58 us | 1.00 | same | 4.51 KB | 4.51 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | base | 1.08 us / 1.27 KB | 930.43 ns / 1.27 KB | 729.72 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | pr | 340.59 ns / 376 B | 342.45 ns / 376 B | 343.76 ns / 376 B |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | base | 682.12 ns / 1.27 KB | 682.25 ns / 1.27 KB | 687.63 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | pr | 329.38 ns / 376 B | 310.47 ns / 376 B | 323.71 ns / 376 B |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | base | 1.49 us / 1.19 KB | 881.85 ns / 1.19 KB | 679.01 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | pr | 311.38 ns / 200 B | 299.81 ns / 200 B | 297.67 ns / 200 B |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | base | 606.51 ns / 1.19 KB | 663.63 ns / 1.19 KB | 585.61 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | pr | 296.32 ns / 200 B | 286.88 ns / 200 B | 305.07 ns / 200 B |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.81 us / 7.16 KB | 6.78 us / 7.16 KB | 6.55 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.39 us / 6.52 KB | 6.67 us / 6.52 KB | 6.28 us / 6.52 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.46 us / 7.16 KB | 6.96 us / 7.16 KB | 6.50 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.56 us / 6.52 KB | 6.30 us / 6.52 KB | 6.30 us / 6.52 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.38 us / 4.29 KB | 6.18 us / 4.29 KB | 6.17 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 6.04 us / 4.29 KB | 6.52 us / 4.29 KB | 6.25 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 5.96 us / 4.29 KB | 6.27 us / 4.29 KB | 6.03 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 6.20 us / 4.29 KB | 6.03 us / 4.29 KB | 6.00 us / 4.29 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 8.93 us / 5.40 KB | 7.23 us / 5.40 KB | 6.86 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.22 us / 4.49 KB | 6.37 us / 4.49 KB | 6.35 us / 4.49 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 6.63 us / 5.40 KB | 6.62 us / 5.40 KB | 6.71 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.30 us / 4.49 KB | 6.18 us / 4.49 KB | 6.24 us / 4.49 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 9.03 us / 4.44 KB | 5.77 us / 4.44 KB | 5.53 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 4.93 us / 3.45 KB | 5.05 us / 3.45 KB | 4.95 us / 3.45 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.35 us / 4.44 KB | 5.37 us / 4.44 KB | 5.39 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.02 us / 3.45 KB | 4.95 us / 3.45 KB | 5.01 us / 3.45 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.85 us / 4.51 KB | 5.96 us / 4.51 KB | 5.72 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.68 us / 4.51 KB | 5.91 us / 4.51 KB | 5.67 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.52 us / 4.51 KB | 5.66 us / 4.51 KB | 5.57 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.71 us / 4.51 KB | 5.56 us / 4.51 KB | 5.58 us / 4.51 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.28 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
