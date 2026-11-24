### BenchmarkDotNet A/B results

- Base: `3cf3bc5aa116b5154b85c443aab67e49098fe3ca`
- PR: `152274655caf6527cb3abf3e3048d2166c07034b`
- Filter: `*SigningBenchmarks.*Sign*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/14 rows faster, 14/14 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.45 us | 6.45 us | 1.00 | same | 6.63 KB | 5.59 KB | 0.84 | less |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.21 us | 6.15 us | 0.99 | same | 6.63 KB | 5.59 KB | 0.84 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 5.98 us | 5.92 us | 0.99 | same | 3.73 KB | 2.43 KB | 0.65 | less |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 5.98 us | 5.84 us | 0.98 | same | 3.73 KB | 2.43 KB | 0.65 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | 6.81 us | 6.77 us | 1.00 | same | 5.62 KB | 4.31 KB | 0.77 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | 6.76 us | 6.63 us | 0.98 | same | 5.62 KB | 4.31 KB | 0.77 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.70 us | 6.75 us | 1.01 | same | 4.86 KB | 3.58 KB | 0.74 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.75 us | 6.55 us | 0.97 | same | 4.86 KB | 3.58 KB | 0.74 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.37 us | 5.36 us | 1.00 | same | 3.91 KB | 2.98 KB | 0.76 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.33 us | 5.19 us | 0.97 | same | 3.91 KB | 2.98 KB | 0.76 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.61 us | 5.54 us | 0.99 | same | 3.98 KB | 2.88 KB | 0.72 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.46 us | 5.33 us | 0.98 | same | 3.98 KB | 2.88 KB | 0.72 | less |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | 6.62 us | 6.65 us | 1.00 | same | 5.31 KB | 3.88 KB | 0.73 | less |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | 6.64 us | 6.50 us | 0.98 | same | 5.31 KB | 3.88 KB | 0.73 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.30 us / 6.63 KB | 6.53 us / 6.63 KB | 6.45 us / 6.63 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.33 us / 5.59 KB | 6.45 us / 5.59 KB | 11.29 us / 5.59 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.07 us / 6.63 KB | 6.46 us / 6.63 KB | 6.21 us / 6.63 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.20 us / 5.59 KB | 6.15 us / 5.59 KB | 6.09 us / 5.59 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.00 us / 3.73 KB | 5.97 us / 3.73 KB | 5.98 us / 3.73 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.87 us / 2.43 KB | 5.92 us / 2.43 KB | 8.61 us / 2.43 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 5.89 us / 3.73 KB | 5.98 us / 3.73 KB | 5.98 us / 3.73 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 5.84 us / 2.43 KB | 5.97 us / 2.43 KB | 5.72 us / 2.43 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | base | 6.81 us / 5.62 KB | 6.84 us / 5.62 KB | 6.66 us / 5.62 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | pr | 6.77 us / 4.31 KB | 6.82 us / 4.31 KB | 6.56 us / 4.31 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | base | 6.64 us / 5.62 KB | 6.76 us / 5.62 KB | 6.80 us / 5.62 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | pr | 6.63 us / 4.31 KB | 6.68 us / 4.31 KB | 6.41 us / 4.31 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.64 us / 4.86 KB | 6.70 us / 4.86 KB | 6.75 us / 4.86 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.67 us / 3.58 KB | 6.75 us / 3.58 KB | 10.06 us / 3.58 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 6.67 us / 4.86 KB | 6.75 us / 4.86 KB | 7.50 us / 4.86 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.57 us / 3.58 KB | 6.55 us / 3.58 KB | 6.45 us / 3.58 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.37 us / 3.91 KB | 5.41 us / 3.91 KB | 5.36 us / 3.91 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.36 us / 2.98 KB | 5.39 us / 2.98 KB | 5.24 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.31 us / 3.91 KB | 5.33 us / 3.91 KB | 5.33 us / 3.91 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.19 us / 2.98 KB | 5.25 us / 2.98 KB | 5.10 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.61 us / 3.98 KB | 5.62 us / 3.98 KB | 5.52 us / 3.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.51 us / 2.88 KB | 5.54 us / 2.88 KB | 8.11 us / 2.88 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.29 us / 3.98 KB | 5.57 us / 3.98 KB | 5.46 us / 3.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.34 us / 2.88 KB | 5.33 us / 2.88 KB | 5.32 us / 2.88 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | base | 6.62 us / 5.31 KB | 6.78 us / 5.31 KB | 6.51 us / 5.31 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | pr | 6.69 us / 3.88 KB | 6.65 us / 3.88 KB | 6.49 us / 3.88 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | base | 6.63 us / 5.31 KB | 6.64 us / 5.31 KB | 6.68 us / 5.31 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | pr | 6.52 us / 3.88 KB | 6.50 us / 3.88 KB | 6.32 us / 3.88 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
