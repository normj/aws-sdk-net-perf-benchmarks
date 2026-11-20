### BenchmarkDotNet A/B results

- Base: `ab7f1c8a3f257e59c3ef8a828cb8a9082cc779bb`
- PR: `3cc5d5c3e77541e1e1c1e2a66c61dcef8f80c276`
- Filter: `*SigningBenchmarks*`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Verdict is `faster` or `slower` only when the change is at least 5% and every PR round beats (or loses to) every base round.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Base alloc | PR alloc | Alloc ratio | Verdict |
|---|---|---:|---:|---:|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.40 us | 6.19 us | 0.97 | 7.16 KB | 6.12 KB | 0.85 | same |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.26 us | 6.26 us | 1.00 | 7.16 KB | 6.12 KB | 0.85 | same |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.19 us | 6.01 us | 0.97 | 4.29 KB | 2.98 KB | 0.70 | same |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.24 us | 6.18 us | 0.99 | 4.29 KB | 2.98 KB | 0.70 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.70 us | 5.44 us | 0.95 | 4.51 KB | 3.41 KB | 0.76 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.62 us | 5.49 us | 0.98 | 4.51 KB | 3.41 KB | 0.76 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.40 us / 7.16 KB | 6.36 us / 7.16 KB | 6.40 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.16 us / 6.12 KB | 6.19 us / 6.12 KB | 6.25 us / 6.12 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.26 us / 7.16 KB | 6.27 us / 7.16 KB | 6.19 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.26 us / 6.12 KB | 6.26 us / 6.12 KB | 6.19 us / 6.12 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.19 us / 4.29 KB | 6.20 us / 4.29 KB | 6.03 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 6.01 us / 2.98 KB | 6.09 us / 2.98 KB | 5.92 us / 2.98 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.24 us / 4.29 KB | 6.27 us / 4.29 KB | 6.07 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 6.18 us / 2.98 KB | 6.23 us / 2.98 KB | 6.09 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.70 us / 4.51 KB | 5.70 us / 4.51 KB | 5.54 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.39 us / 3.41 KB | 5.44 us / 3.41 KB | 5.47 us / 3.41 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.62 us / 4.51 KB | 5.62 us / 4.51 KB | 5.59 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.49 us / 3.41 KB | 5.49 us / 3.41 KB | 5.54 us / 3.41 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.8 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.87 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
```

</details>
