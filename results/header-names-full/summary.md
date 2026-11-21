### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `321ec6ee997ee0dcf4ca9d3827c01e9030db7685`
- Filter: `*SigningBenchmarks.*Sign*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/10 rows faster, 8/10 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.41 us | 6.39 us | 1.00 | same | 7.16 KB | 7.10 KB | 0.99 | same |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.50 us | 6.68 us | 1.03 | same | 7.16 KB | 7.10 KB | 0.99 | same |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 5.99 us | 6.01 us | 1.00 | same | 4.29 KB | 3.91 KB | 0.91 | less |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.13 us | 6.05 us | 0.99 | same | 4.29 KB | 3.91 KB | 0.91 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.70 us | 6.68 us | 1.00 | same | 5.40 KB | 5.07 KB | 0.94 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.71 us | 6.64 us | 0.99 | same | 5.40 KB | 5.07 KB | 0.94 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.48 us | 5.37 us | 0.98 | same | 4.44 KB | 4.21 KB | 0.95 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.39 us | 5.41 us | 1.00 | same | 4.44 KB | 4.21 KB | 0.95 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.60 us | 5.55 us | 0.99 | same | 4.51 KB | 4.28 KB | 0.95 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.68 us | 5.56 us | 0.98 | same | 4.51 KB | 4.28 KB | 0.95 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.46 us / 7.16 KB | 6.38 us / 7.16 KB | 6.41 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.37 us / 7.10 KB | 6.39 us / 7.10 KB | 6.69 us / 7.10 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.95 us / 7.16 KB | 6.50 us / 7.16 KB | 6.37 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.68 us / 7.10 KB | 6.63 us / 7.10 KB | 6.80 us / 7.10 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.10 us / 4.29 KB | 5.99 us / 4.29 KB | 5.99 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 6.01 us / 3.91 KB | 5.95 us / 3.91 KB | 6.03 us / 3.91 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.13 us / 4.29 KB | 5.99 us / 4.29 KB | 6.14 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 6.03 us / 3.91 KB | 6.05 us / 3.91 KB | 6.11 us / 3.91 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.83 us / 5.40 KB | 6.70 us / 5.40 KB | 6.69 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.56 us / 5.07 KB | 6.72 us / 5.07 KB | 6.68 us / 5.07 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 7.25 us / 5.40 KB | 6.65 us / 5.40 KB | 6.71 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.58 us / 5.07 KB | 6.64 us / 5.07 KB | 6.82 us / 5.07 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 6.59 us / 4.44 KB | 5.48 us / 4.44 KB | 5.42 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.38 us / 4.21 KB | 5.31 us / 4.21 KB | 5.37 us / 4.21 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.69 us / 4.44 KB | 5.36 us / 4.44 KB | 5.39 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.36 us / 4.21 KB | 5.41 us / 4.21 KB | 6.39 us / 4.21 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.86 us / 4.51 KB | 5.59 us / 4.51 KB | 5.60 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.55 us / 4.28 KB | 5.52 us / 4.28 KB | 5.69 us / 4.28 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.77 us / 4.51 KB | 5.56 us / 4.51 KB | 5.68 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.55 us / 4.28 KB | 5.56 us / 4.28 KB | 5.69 us / 4.28 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.68 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
