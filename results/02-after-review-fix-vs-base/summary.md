### BenchmarkDotNet A/B results

- Base: `ab7f1c8a3f257e59c3ef8a828cb8a9082cc779bb`
- PR: `3d6df20eb0728fbf18d6b40f6cba2c7268ac6332`
- Filter: `*SigningBenchmarks*`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Verdict is `faster` or `slower` only when the change is at least 5% and every PR round beats (or loses to) every base round.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Base alloc | PR alloc | Alloc ratio | Verdict |
|---|---|---:|---:|---:|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.54 us | 6.58 us | 1.01 | 7.16 KB | 6.12 KB | 0.85 | same |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.57 us | 6.52 us | 0.99 | 7.16 KB | 6.12 KB | 0.85 | same |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.40 us | 6.22 us | 0.97 | 4.29 KB | 2.98 KB | 0.70 | same |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.40 us | 6.40 us | 1.00 | 4.29 KB | 2.98 KB | 0.70 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.80 us | 5.65 us | 0.97 | 4.51 KB | 3.41 KB | 0.76 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.73 us | 5.78 us | 1.01 | 4.51 KB | 3.41 KB | 0.76 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.35 us / 7.16 KB | 6.79 us / 7.16 KB | 6.54 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.58 us / 6.12 KB | 6.71 us / 6.12 KB | 6.47 us / 6.12 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.47 us / 7.16 KB | 6.69 us / 7.16 KB | 6.57 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.55 us / 6.12 KB | 6.52 us / 6.12 KB | 6.41 us / 6.12 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.40 us / 4.29 KB | 6.41 us / 4.29 KB | 6.39 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 6.23 us / 2.98 KB | 6.11 us / 2.98 KB | 6.22 us / 2.98 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.12 us / 4.29 KB | 6.51 us / 4.29 KB | 6.40 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 6.40 us / 2.98 KB | 6.27 us / 2.98 KB | 6.48 us / 2.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.63 us / 4.51 KB | 5.88 us / 4.51 KB | 5.80 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.65 us / 3.41 KB | 5.65 us / 3.41 KB | 5.63 us / 3.41 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.68 us / 4.51 KB | 5.78 us / 4.51 KB | 5.73 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.79 us / 3.41 KB | 5.78 us / 3.41 KB | 5.74 us / 3.41 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.45 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.38 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
```

</details>
