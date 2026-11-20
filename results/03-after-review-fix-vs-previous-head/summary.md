### BenchmarkDotNet A/B results

- Base: `3cc5d5c3e77541e1e1c1e2a66c61dcef8f80c276`
- PR: `3d6df20eb0728fbf18d6b40f6cba2c7268ac6332`
- Filter: `*SigningBenchmarks*`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Verdict is `faster` or `slower` only when the change is at least 5% and every PR round beats (or loses to) every base round.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Base alloc | PR alloc | Alloc ratio | Verdict |
|---|---|---:|---:|---:|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.56 us | 6.59 us | 1.00 | 6.12 KB | 6.12 KB | 1.00 | same |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.56 us | 6.53 us | 1.00 | 6.12 KB | 6.12 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.17 us | 6.19 us | 1.00 | 2.98 KB | 2.98 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.40 us | 6.32 us | 0.99 | 2.98 KB | 2.98 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.62 us | 5.62 us | 1.00 | 3.41 KB | 3.41 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.67 us | 5.72 us | 1.01 | 3.41 KB | 3.41 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.48 us / 6.12 KB | 6.57 us / 6.12 KB | 6.56 us / 6.12 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.56 us / 6.12 KB | 6.59 us / 6.12 KB | 6.69 us / 6.12 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.48 us / 6.12 KB | 6.56 us / 6.12 KB | 6.72 us / 6.12 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.58 us / 6.12 KB | 6.47 us / 6.12 KB | 6.53 us / 6.12 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.17 us / 2.98 KB | 6.09 us / 2.98 KB | 6.17 us / 2.98 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 7.07 us / 2.98 KB | 6.15 us / 2.98 KB | 6.19 us / 2.98 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.43 us / 2.98 KB | 6.38 us / 2.98 KB | 6.40 us / 2.98 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 6.31 us / 2.98 KB | 6.32 us / 2.98 KB | 6.44 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.56 us / 3.41 KB | 5.65 us / 3.41 KB | 5.62 us / 3.41 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.62 us / 3.41 KB | 5.59 us / 3.41 KB | 5.74 us / 3.41 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.63 us / 3.41 KB | 5.67 us / 3.41 KB | 5.90 us / 3.41 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.72 us / 3.41 KB | 5.66 us / 3.41 KB | 5.75 us / 3.41 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.29 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.7 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
```

</details>
