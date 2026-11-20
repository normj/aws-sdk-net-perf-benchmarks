### BenchmarkDotNet A/B results

- Base: `ab7f1c8a3f257e59c3ef8a828cb8a9082cc779bb`
- PR: `f5ee0c95781cebcc21b5c079cec92c81e017bafc`
- Filter: `*SigningBenchmarks*`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Verdict is `faster` or `slower` only when the change is at least 5% and every PR round beats (or loses to) every base round.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Base alloc | PR alloc | Alloc ratio | Verdict |
|---|---|---:|---:|---:|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.44 us | 6.01 us | 0.93 | 7.16 KB | 6.63 KB | 0.93 | faster |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.23 us | 5.87 us | 0.94 | 7.16 KB | 6.63 KB | 0.93 | faster |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.07 us | 5.78 us | 0.95 | 4.29 KB | 3.73 KB | 0.87 | same |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.12 us | 5.74 us | 0.94 | 4.29 KB | 3.73 KB | 0.87 | faster |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.60 us | 5.21 us | 0.93 | 4.51 KB | 3.98 KB | 0.88 | faster |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.57 us | 5.22 us | 0.94 | 4.51 KB | 3.98 KB | 0.88 | faster |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.45 us / 7.16 KB | 6.44 us / 7.16 KB | 6.27 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 5.99 us / 6.63 KB | 6.02 us / 6.63 KB | 6.01 us / 6.63 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.23 us / 7.16 KB | 6.19 us / 7.16 KB | 6.28 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 5.87 us / 6.63 KB | 5.86 us / 6.63 KB | 5.87 us / 6.63 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.09 us / 4.29 KB | 6.07 us / 4.29 KB | 6.07 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.78 us / 3.73 KB | 5.81 us / 3.73 KB | 5.76 us / 3.73 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.11 us / 4.29 KB | 6.15 us / 4.29 KB | 6.12 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 5.74 us / 3.73 KB | 5.77 us / 3.73 KB | 5.74 us / 3.73 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.63 us / 4.51 KB | 5.49 us / 4.51 KB | 5.60 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.29 us / 3.98 KB | 5.21 us / 3.98 KB | 5.21 us / 3.98 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.57 us / 4.51 KB | 5.50 us / 4.51 KB | 5.63 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.19 us / 3.98 KB | 5.23 us / 3.98 KB | 5.22 us / 3.98 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.89 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.96 GB Available
.NET SDK 11.0.100
  [Host]     : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  DefaultJob : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
```

</details>
