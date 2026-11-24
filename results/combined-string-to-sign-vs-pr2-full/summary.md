### BenchmarkDotNet A/B results

- Base: `37aaf04a22216e584cb8fa557ee4a05b5bf03a5d`
- PR: `152274655caf6527cb3abf3e3048d2166c07034b`
- Filter: `*SigningBenchmarks.*Sign*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 4/14 rows faster, 14/14 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.88 us | 6.04 us | 0.88 | same | 6.12 KB | 5.59 KB | 0.91 | less |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.72 us | 6.28 us | 0.93 | same | 6.12 KB | 5.59 KB | 0.91 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.17 us | 5.93 us | 0.96 | same | 2.98 KB | 2.43 KB | 0.81 | less |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.27 us | 5.78 us | 0.92 | faster | 2.98 KB | 2.43 KB | 0.81 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | 7.12 us | 6.72 us | 0.94 | same | 4.87 KB | 4.31 KB | 0.89 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | 6.90 us | 6.64 us | 0.96 | same | 4.87 KB | 4.31 KB | 0.89 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 7.11 us | 6.60 us | 0.93 | same | 4.12 KB | 3.58 KB | 0.87 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.80 us | 6.55 us | 0.96 | same | 4.12 KB | 3.58 KB | 0.87 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.69 us | 5.28 us | 0.93 | same | 3.50 KB | 2.98 KB | 0.85 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.44 us | 5.16 us | 0.95 | faster | 3.50 KB | 2.98 KB | 0.85 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.84 us | 5.49 us | 0.94 | same | 3.41 KB | 2.88 KB | 0.85 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.84 us | 5.34 us | 0.92 | faster | 3.41 KB | 2.88 KB | 0.85 | less |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | 7.07 us | 6.59 us | 0.93 | faster | 4.40 KB | 3.88 KB | 0.88 | less |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | 6.85 us | 6.51 us | 0.95 | same | 4.40 KB | 3.88 KB | 0.88 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 7.00 us / 6.12 KB | 6.40 us / 6.12 KB | 6.88 us / 6.12 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.04 us / 5.59 KB | 6.54 us / 5.59 KB | 6.02 us / 5.59 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.42 us / 6.12 KB | 6.72 us / 6.12 KB | 6.87 us / 6.12 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.01 us / 5.59 KB | 6.53 us / 5.59 KB | 6.28 us / 5.59 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.30 us / 2.98 KB | 5.95 us / 2.98 KB | 6.17 us / 2.98 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.93 us / 2.43 KB | 5.97 us / 2.43 KB | 5.81 us / 2.43 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.27 us / 2.98 KB | 6.18 us / 2.98 KB | 6.31 us / 2.98 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 5.71 us / 2.43 KB | 6.01 us / 2.43 KB | 5.78 us / 2.43 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | base | 7.18 us / 4.87 KB | 6.89 us / 4.87 KB | 7.12 us / 4.87 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | pr | 6.55 us / 4.31 KB | 6.93 us / 4.31 KB | 6.72 us / 4.31 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | base | 6.89 us / 4.87 KB | 7.12 us / 4.87 KB | 6.90 us / 4.87 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | pr | 6.58 us / 4.31 KB | 6.76 us / 4.31 KB | 6.64 us / 4.31 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 7.11 us / 4.12 KB | 6.62 us / 4.12 KB | 7.14 us / 4.12 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.57 us / 3.58 KB | 6.79 us / 3.58 KB | 6.60 us / 3.58 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 6.65 us / 4.12 KB | 6.90 us / 4.12 KB | 6.80 us / 4.12 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.38 us / 3.58 KB | 6.69 us / 3.58 KB | 6.55 us / 3.58 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.79 us / 3.50 KB | 5.39 us / 3.50 KB | 5.69 us / 3.50 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.28 us / 2.98 KB | 5.47 us / 2.98 KB | 5.27 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.32 us / 3.50 KB | 5.69 us / 3.50 KB | 5.44 us / 3.50 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.14 us / 2.98 KB | 5.30 us / 2.98 KB | 5.16 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.95 us / 3.41 KB | 5.55 us / 3.41 KB | 5.84 us / 3.41 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.49 us / 2.88 KB | 5.64 us / 2.88 KB | 5.37 us / 2.88 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.89 us / 3.41 KB | 5.78 us / 3.41 KB | 5.84 us / 3.41 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.26 us / 2.88 KB | 5.52 us / 2.88 KB | 5.34 us / 2.88 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | base | 7.15 us / 4.40 KB | 6.92 us / 4.40 KB | 7.07 us / 4.40 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net10.0 | pr | 6.52 us / 3.88 KB | 6.76 us / 3.88 KB | 6.59 us / 3.88 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | base | 6.85 us / 4.40 KB | 7.01 us / 4.40 KB | 6.59 us / 4.40 KB |
| SigningBenchmarks.Sign_S3PutTrailingChecksum | net11.0 | pr | 6.38 us / 3.88 KB | 6.65 us / 3.88 KB | 6.51 us / 3.88 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.8 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
