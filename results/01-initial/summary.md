### BenchmarkDotNet A/B results

- Base: `ab7f1c8a3f257e59c3ef8a828cb8a9082cc779bb`
- PR: `f197dda7e9f31d7d0e2af7e5496d43a5d15e1c7e`
- Filter: `*SigningBenchmarks*`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Verdict is `faster` or `slower` only when the change is at least 5% and every PR round beats (or loses to) every base round.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Base alloc | PR alloc | Alloc ratio | Verdict |
|---|---|---:|---:|---:|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.64 us | 6.61 us | 1.00 | 7.16 KB | 7.16 KB | 1.00 | same |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.66 us | 6.51 us | 0.98 | 7.16 KB | 7.16 KB | 1.00 | same |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.35 us | 5.73 us | 0.90 | 4.29 KB | 4.29 KB | 1.00 | faster |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.38 us | 5.81 us | 0.91 | 4.29 KB | 4.29 KB | 1.00 | faster |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.80 us | 5.34 us | 0.92 | 4.51 KB | 4.51 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.73 us | 5.23 us | 0.91 | 4.51 KB | 4.51 KB | 1.00 | faster |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.60 us / 7.16 KB | 6.68 us / 7.16 KB | 6.64 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.64 us / 7.16 KB | 6.53 us / 7.16 KB | 6.61 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.66 us / 7.16 KB | 6.67 us / 7.16 KB | 6.63 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.51 us / 7.16 KB | 6.57 us / 7.16 KB | 6.42 us / 7.16 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.36 us / 4.29 KB | 6.35 us / 4.29 KB | 6.34 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.84 us / 4.29 KB | 5.73 us / 4.29 KB | 5.67 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.37 us / 4.29 KB | 6.38 us / 4.29 KB | 6.38 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 5.81 us / 4.29 KB | 5.71 us / 4.29 KB | 5.84 us / 4.29 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.80 us / 4.51 KB | 5.82 us / 4.51 KB | 5.74 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 7.55 us / 4.51 KB | 5.27 us / 4.51 KB | 5.34 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.73 us / 4.51 KB | 5.72 us / 4.51 KB | 5.83 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.23 us / 4.51 KB | 5.29 us / 4.51 KB | 5.23 us / 4.51 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.98 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.52 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
```

</details>
