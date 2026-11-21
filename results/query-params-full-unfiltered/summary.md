### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `0ce114a2c17da19a068f8f579b472d79632fffc8`
- Filter: `*SigningBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** regression. At least one row is slower or allocates more.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | 713.83 ns | 741.43 ns | 1.04 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | 682.85 ns | 709.55 ns | 1.04 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | 671.52 ns | 670.84 ns | 1.00 | same | 1.19 KB | 1.19 KB | 1.00 | same |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | 580.35 ns | 619.94 ns | 1.07 | **slower** | 1.19 KB | 1.19 KB | 1.00 | same |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.52 us | 6.37 us | 0.98 | same | 7.16 KB | 6.82 KB | 0.95 | less |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.54 us | 6.54 us | 1.00 | same | 7.16 KB | 6.82 KB | 0.95 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.15 us | 6.03 us | 0.98 | same | 4.29 KB | 4.29 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.02 us | 6.06 us | 1.01 | same | 4.29 KB | 4.29 KB | 1.00 | same |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.84 us | 6.77 us | 0.99 | same | 5.40 KB | 5.40 KB | 1.00 | same |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.75 us | 6.73 us | 1.00 | same | 5.40 KB | 5.40 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.47 us | 5.47 us | 1.00 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.41 us | 5.41 us | 1.00 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.71 us | 5.37 us | 0.94 | faster | 4.51 KB | 3.99 KB | 0.89 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.59 us | 5.37 us | 0.96 | same | 4.51 KB | 3.99 KB | 0.89 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | base | 1.07 us / 1.27 KB | 711.94 ns / 1.27 KB | 713.83 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | pr | 738.55 ns / 1.27 KB | 741.43 ns / 1.27 KB | 751.10 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | base | 669.74 ns / 1.27 KB | 697.27 ns / 1.27 KB | 682.85 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | pr | 705.22 ns / 1.27 KB | 709.55 ns / 1.27 KB | 714.00 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | base | 671.14 ns / 1.19 KB | 671.52 ns / 1.19 KB | 677.13 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net10.0 | pr | 670.84 ns / 1.19 KB | 660.37 ns / 1.19 KB | 677.52 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | base | 578.68 ns / 1.19 KB | 580.35 ns / 1.19 KB | 583.72 ns / 1.19 KB |
| SigningBenchmarks.CanonicalizeResourcePath_S3Key | net11.0 | pr | 636.68 ns / 1.19 KB | 619.94 ns / 1.19 KB | 604.03 ns / 1.19 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.54 us / 7.16 KB | 6.52 us / 7.16 KB | 6.34 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.37 us / 6.82 KB | 6.41 us / 6.82 KB | 6.36 us / 6.82 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.55 us / 7.16 KB | 6.48 us / 7.16 KB | 6.54 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.52 us / 6.82 KB | 6.54 us / 6.82 KB | 6.60 us / 6.82 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.31 us / 4.29 KB | 6.01 us / 4.29 KB | 6.15 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 6.03 us / 4.29 KB | 6.02 us / 4.29 KB | 6.05 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.02 us / 4.29 KB | 5.98 us / 4.29 KB | 6.12 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 6.15 us / 4.29 KB | 6.05 us / 4.29 KB | 6.06 us / 4.29 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.94 us / 5.40 KB | 6.72 us / 5.40 KB | 6.84 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 7.18 us / 5.40 KB | 6.77 us / 5.40 KB | 6.74 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 7.49 us / 5.40 KB | 6.61 us / 5.40 KB | 6.75 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.80 us / 5.40 KB | 6.73 us / 5.40 KB | 6.70 us / 5.40 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.47 us / 4.44 KB | 5.41 us / 4.44 KB | 5.53 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.47 us / 4.44 KB | 5.47 us / 4.44 KB | 5.46 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.41 us / 4.44 KB | 5.36 us / 4.44 KB | 5.53 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.41 us / 4.44 KB | 5.39 us / 4.44 KB | 5.41 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.72 us / 4.51 KB | 5.70 us / 4.51 KB | 5.71 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.33 us / 3.99 KB | 5.39 us / 3.99 KB | 5.37 us / 3.99 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.59 us / 4.51 KB | 5.53 us / 4.51 KB | 5.61 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.37 us / 3.99 KB | 5.35 us / 3.99 KB | 5.38 us / 3.99 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.88 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
