### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `152274655caf6527cb3abf3e3048d2166c07034b`
- Filter: `*SigningBenchmarks.*Sign*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 6/14 rows faster, 14/14 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.48 us | 6.50 us | 1.00 | same | 7.16 KB | 5.59 KB | 0.78 | less |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.52 us | 6.15 us | 0.94 | faster | 7.16 KB | 5.59 KB | 0.78 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.07 us | 5.78 us | 0.95 | same | 4.29 KB | 2.43 KB | 0.57 | less |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.12 us | 5.63 us | 0.92 | faster | 4.29 KB | 2.43 KB | 0.57 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | 6.79 us | 6.55 us | 0.97 | same | 6.17 KB | 4.31 KB | 0.70 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | 6.81 us | 6.39 us | 0.94 | faster | 6.17 KB | 4.31 KB | 0.70 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.75 us | 6.54 us | 0.97 | same | 5.40 KB | 3.58 KB | 0.66 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.78 us | 6.54 us | 0.96 | same | 5.40 KB | 3.58 KB | 0.66 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.43 us | 5.14 us | 0.95 | faster | 4.44 KB | 2.98 KB | 0.67 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.44 us | 5.21 us | 0.96 | same | 4.44 KB | 2.98 KB | 0.67 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.62 us | 5.38 us | 0.96 | same | 4.51 KB | 2.88 KB | 0.64 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.66 us | 5.26 us | 0.93 | faster | 4.51 KB | 2.88 KB | 0.64 | less |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | 6.72 us | 6.50 us | 0.97 | same | 5.84 KB | 3.88 KB | 0.66 | less |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | 6.78 us | 6.31 us | 0.93 | faster | 5.84 KB | 3.88 KB | 0.66 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.72 us / 7.16 KB | 6.46 us / 7.16 KB | 6.48 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.50 us / 5.59 KB | 6.59 us / 5.59 KB | 6.06 us / 5.59 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.55 us / 7.16 KB | 6.47 us / 7.16 KB | 6.52 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.32 us / 5.59 KB | 6.01 us / 5.59 KB | 6.15 us / 5.59 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.26 us / 4.29 KB | 6.07 us / 4.29 KB | 6.04 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.78 us / 2.43 KB | 5.91 us / 2.43 KB | 5.77 us / 2.43 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.17 us / 4.29 KB | 6.12 us / 4.29 KB | 6.10 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 5.63 us / 2.43 KB | 5.63 us / 2.43 KB | 5.69 us / 2.43 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | base | 6.78 us / 6.17 KB | 6.92 us / 6.17 KB | 6.79 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | pr | 6.66 us / 4.31 KB | 6.49 us / 4.31 KB | 6.55 us / 4.31 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | base | 6.86 us / 6.17 KB | 6.81 us / 6.17 KB | 6.74 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | pr | 6.34 us / 4.31 KB | 6.39 us / 4.31 KB | 6.59 us / 4.31 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.75 us / 5.40 KB | 6.67 us / 5.40 KB | 6.85 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.75 us / 3.58 KB | 6.54 us / 3.58 KB | 6.53 us / 3.58 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 6.81 us / 5.40 KB | 6.78 us / 5.40 KB | 6.72 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.69 us / 3.58 KB | 6.38 us / 3.58 KB | 6.54 us / 3.58 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.43 us / 4.44 KB | 5.99 us / 4.44 KB | 5.42 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.17 us / 2.98 KB | 5.14 us / 2.98 KB | 5.09 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.55 us / 4.44 KB | 5.44 us / 4.44 KB | 5.42 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.21 us / 2.98 KB | 5.07 us / 2.98 KB | 5.26 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.63 us / 4.51 KB | 5.60 us / 4.51 KB | 5.62 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.38 us / 2.88 KB | 5.80 us / 2.88 KB | 5.29 us / 2.88 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.67 us / 4.51 KB | 5.57 us / 4.51 KB | 5.66 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.43 us / 2.88 KB | 5.24 us / 2.88 KB | 5.26 us / 2.88 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | base | 6.72 us / 5.84 KB | 7.53 us / 5.84 KB | 6.69 us / 5.84 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | pr | 6.70 us / 3.88 KB | 6.50 us / 3.88 KB | 6.39 us / 3.88 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | base | 6.83 us / 5.84 KB | 6.68 us / 5.84 KB | 6.78 us / 5.84 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | pr | 6.31 us / 3.88 KB | 6.31 us / 3.88 KB | 6.57 us / 3.88 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.59 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
