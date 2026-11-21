### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d5b30f35c83d9bbf80c0aa139ed8dafcb20e7921`
- Filter: `*SigningBenchmarks.*Sign*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.4 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/10 rows faster, 10/10 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.45 us | 5.80 us | 0.90 | faster | 7.16 KB | 6.01 KB | 0.84 | less |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.53 us | 6.15 us | 0.94 | faster | 7.16 KB | 6.01 KB | 0.84 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 5.99 us | 5.94 us | 0.99 | same | 4.29 KB | 4.14 KB | 0.97 | less |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.08 us | 6.04 us | 0.99 | same | 4.29 KB | 4.14 KB | 0.97 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.71 us | 6.66 us | 0.99 | same | 5.40 KB | 5.25 KB | 0.97 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.79 us | 6.71 us | 0.99 | same | 5.40 KB | 5.25 KB | 0.97 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.45 us | 5.44 us | 1.00 | same | 4.44 KB | 4.29 KB | 0.97 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.41 us | 5.43 us | 1.00 | same | 4.44 KB | 4.29 KB | 0.97 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.60 us | 5.54 us | 0.99 | same | 4.51 KB | 4.36 KB | 0.97 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.62 us | 5.67 us | 1.01 | same | 4.51 KB | 4.36 KB | 0.97 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.41 us / 7.16 KB | 6.45 us / 7.16 KB | 6.47 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 5.86 us / 6.01 KB | 5.71 us / 6.01 KB | 5.80 us / 6.01 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.76 us / 7.16 KB | 6.40 us / 7.16 KB | 6.53 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.18 us / 6.01 KB | 6.15 us / 6.01 KB | 5.99 us / 6.01 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.05 us / 4.29 KB | 5.99 us / 4.29 KB | 5.99 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.95 us / 4.14 KB | 5.94 us / 4.14 KB | 5.89 us / 4.14 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.25 us / 4.29 KB | 6.03 us / 4.29 KB | 6.08 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 6.04 us / 4.14 KB | 5.94 us / 4.14 KB | 6.05 us / 4.14 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.71 us / 5.40 KB | 6.69 us / 5.40 KB | 6.73 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.72 us / 5.25 KB | 6.66 us / 5.25 KB | 6.62 us / 5.25 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 6.82 us / 5.40 KB | 6.71 us / 5.40 KB | 6.79 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.71 us / 5.25 KB | 6.66 us / 5.25 KB | 6.73 us / 5.25 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.45 us / 4.44 KB | 5.40 us / 4.44 KB | 5.56 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.45 us / 4.29 KB | 5.42 us / 4.29 KB | 5.44 us / 4.29 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 5.53 us / 4.44 KB | 5.39 us / 4.44 KB | 5.41 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.43 us / 4.29 KB | 5.38 us / 4.29 KB | 5.47 us / 4.29 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.71 us / 4.51 KB | 5.60 us / 4.51 KB | 5.60 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.52 us / 4.36 KB | 5.57 us / 4.36 KB | 5.54 us / 4.36 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.70 us / 4.51 KB | 5.57 us / 4.51 KB | 5.62 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.67 us / 4.36 KB | 5.85 us / 4.36 KB | 5.63 us / 4.36 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
