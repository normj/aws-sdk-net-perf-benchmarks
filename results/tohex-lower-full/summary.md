### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `67217f870367faffc94a364f187d771caaa9d2dc`
- Filter: `*SigningBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@cee7391b597f9cbd78607fd34b70624136fab65d`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 5/22 rows faster, 0/22 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | 718.05 ns | 713.42 ns | 0.99 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | 696.25 ns | 695.12 ns | 1.00 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | 692.01 ns | 655.97 ns | 0.95 | faster | 1.19 KB | 1.19 KB | 1.00 | same |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | 593.58 ns | 591.50 ns | 1.00 | same | 1.19 KB | 1.19 KB | 1.00 | same |
| SigningBenchmarks.ComputeHash_CanonicalRequest | net10.0 | 1.29 us | 1.29 us | 1.00 | same | 56 B | 56 B | 1.00 | same |
| SigningBenchmarks.ComputeHash_CanonicalRequest | net11.0 | 1.39 us | 1.30 us | 0.94 | faster | 56 B | 56 B | 1.00 | same |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | 868.06 ns | 907.35 ns | 1.05 | same | 1.25 KB | 1.25 KB | 1.00 | same |
| SigningBenchmarks.ContentStreamHash_PooledJson | net11.0 | 937.33 ns | 839.90 ns | 0.90 | faster | 1.25 KB | 1.25 KB | 1.00 | same |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.62 us | 6.36 us | 0.96 | same | 7.16 KB | 7.16 KB | 1.00 | same |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.53 us | 6.46 us | 0.99 | same | 7.16 KB | 7.16 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.06 us | 5.96 us | 0.98 | same | 4.29 KB | 4.29 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.08 us | 5.91 us | 0.97 | same | 4.29 KB | 4.29 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | 6.83 us | 6.69 us | 0.98 | same | 6.17 KB | 6.17 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | 6.75 us | 6.70 us | 0.99 | same | 6.17 KB | 6.17 KB | 1.00 | same |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.78 us | 6.63 us | 0.98 | same | 5.40 KB | 5.40 KB | 1.00 | same |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.74 us | 6.69 us | 0.99 | same | 5.40 KB | 5.40 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.44 us | 5.30 us | 0.97 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.40 us | 5.40 us | 1.00 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.63 us | 5.51 us | 0.98 | same | 4.51 KB | 4.51 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.62 us | 5.52 us | 0.98 | same | 4.51 KB | 4.51 KB | 1.00 | same |
| SigningBenchmarks.ToHex_Sha256Lower | net10.0 | 49.22 ns | 22.46 ns | 0.46 | faster | 152 B | 152 B | 1.00 | same |
| SigningBenchmarks.ToHex_Sha256Lower | net11.0 | 41.85 ns | 17.72 ns | 0.42 | faster | 152 B | 152 B | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | base | 718.05 ns / 1.27 KB | 750.12 ns / 1.27 KB | 713.75 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | pr | 736.91 ns / 1.27 KB | 713.42 ns / 1.27 KB | 713.34 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | base | 696.25 ns / 1.27 KB | 806.98 ns / 1.27 KB | 687.37 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | pr | 695.12 ns / 1.27 KB | 781.04 ns / 1.27 KB | 688.33 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | base | 753.24 ns / 1.19 KB | 692.01 ns / 1.19 KB | 684.82 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | pr | 666.59 ns / 1.19 KB | 637.90 ns / 1.19 KB | 655.97 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | base | 602.14 ns / 1.19 KB | 592.42 ns / 1.19 KB | 593.58 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | pr | 591.50 ns / 1.19 KB | 622.48 ns / 1.19 KB | 590.76 ns / 1.19 KB |
| SigningBenchmarks.ComputeHash_CanonicalRequest | net10.0 | base | 1.29 us / 56 B | 1.29 us / 56 B | 1.29 us / 56 B |
| SigningBenchmarks.ComputeHash_CanonicalRequest | net10.0 | pr | 1.29 us / 56 B | 1.29 us / 56 B | 1.29 us / 56 B |
| SigningBenchmarks.ComputeHash_CanonicalRequest | net11.0 | base | 1.39 us / 56 B | 1.40 us / 56 B | 1.39 us / 56 B |
| SigningBenchmarks.ComputeHash_CanonicalRequest | net11.0 | pr | 1.38 us / 56 B | 1.30 us / 56 B | 1.30 us / 56 B |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | base | 871.17 ns / 1.25 KB | 860.08 ns / 1.25 KB | 868.06 ns / 1.25 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | pr | 920.02 ns / 1.25 KB | 874.83 ns / 1.25 KB | 907.35 ns / 1.25 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net11.0 | base | 940.53 ns / 1.25 KB | 937.33 ns / 1.25 KB | 936.43 ns / 1.25 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net11.0 | pr | 906.08 ns / 1.25 KB | 837.74 ns / 1.25 KB | 839.90 ns / 1.25 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.67 us / 7.16 KB | 6.42 us / 7.16 KB | 6.62 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.36 us / 7.16 KB | 6.29 us / 7.16 KB | 6.38 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.53 us / 7.16 KB | 6.64 us / 7.16 KB | 6.50 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.46 us / 7.16 KB | 6.51 us / 7.16 KB | 6.35 us / 7.16 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.05 us / 4.29 KB | 6.27 us / 4.29 KB | 6.06 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.96 us / 4.29 KB | 5.92 us / 4.29 KB | 5.96 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.08 us / 4.29 KB | 6.04 us / 4.29 KB | 6.08 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 6.08 us / 4.29 KB | 5.90 us / 4.29 KB | 5.91 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | base | 6.75 us / 6.17 KB | 6.85 us / 6.17 KB | 6.83 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | pr | 6.69 us / 6.17 KB | 6.67 us / 6.17 KB | 6.71 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | base | 6.79 us / 6.17 KB | 6.75 us / 6.17 KB | 6.73 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | pr | 6.72 us / 6.17 KB | 6.70 us / 6.17 KB | 6.63 us / 6.17 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.78 us / 5.40 KB | 6.96 us / 5.40 KB | 6.78 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.67 us / 5.40 KB | 6.63 us / 5.40 KB | 6.63 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 6.81 us / 5.40 KB | 6.74 us / 5.40 KB | 6.69 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.74 us / 5.40 KB | 6.69 us / 5.40 KB | 6.61 us / 5.40 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.44 us / 4.44 KB | 5.43 us / 4.44 KB | 5.48 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.36 us / 4.44 KB | 5.25 us / 4.44 KB | 5.30 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.52 us / 4.44 KB | 5.40 us / 4.44 KB | 5.37 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.40 us / 4.44 KB | 5.43 us / 4.44 KB | 5.40 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.67 us / 4.51 KB | 5.56 us / 4.51 KB | 5.63 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.57 us / 4.51 KB | 5.49 us / 4.51 KB | 5.51 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.62 us / 4.51 KB | 5.63 us / 4.51 KB | 5.59 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.55 us / 4.51 KB | 5.52 us / 4.51 KB | 5.52 us / 4.51 KB |
| SigningBenchmarks.ToHex_Sha256Lower | net10.0 | base | 49.06 ns / 152 B | 49.55 ns / 152 B | 49.22 ns / 152 B |
| SigningBenchmarks.ToHex_Sha256Lower | net10.0 | pr | 22.21 ns / 152 B | 22.64 ns / 152 B | 22.46 ns / 152 B |
| SigningBenchmarks.ToHex_Sha256Lower | net11.0 | base | 42.11 ns / 152 B | 41.79 ns / 152 B | 41.85 ns / 152 B |
| SigningBenchmarks.ToHex_Sha256Lower | net11.0 | pr | 17.72 ns / 152 B | 17.72 ns / 152 B | 17.67 ns / 152 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
