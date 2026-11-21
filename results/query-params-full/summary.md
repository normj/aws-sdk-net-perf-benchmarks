### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `0ce114a2c17da19a068f8f579b472d79632fffc8`
- Filter: `*SigningBenchmarks.*S3Get*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@0b1279d66e67db9ed95729ae9da868efeccdf8f3`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/6 rows faster, 4/6 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.49 us | 6.53 us | 1.01 | same | 7.16 KB | 6.82 KB | 0.95 | less |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | 6.53 us | 6.38 us | 0.98 | same | 7.16 KB | 6.82 KB | 0.95 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.57 us | 5.75 us | 1.03 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | 5.35 us | 5.43 us | 1.01 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 8.66 us | 5.82 us | 0.67 | same | 4.51 KB | 3.99 KB | 0.89 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | 5.46 us | 5.42 us | 0.99 | same | 4.51 KB | 3.99 KB | 0.89 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.49 us / 7.16 KB | 8.82 us / 7.16 KB | 6.45 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 7.18 us / 6.82 KB | 6.50 us / 6.82 KB | 6.53 us / 6.82 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | base | 6.53 us / 7.16 KB | 7.23 us / 7.16 KB | 6.42 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net11.0 | pr | 6.77 us / 6.82 KB | 6.33 us / 6.82 KB | 6.38 us / 6.82 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.40 us / 4.44 KB | 5.65 us / 4.44 KB | 5.57 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 6.02 us / 4.44 KB | 5.75 us / 4.44 KB | 5.38 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | base | 6.05 us / 4.44 KB | 5.33 us / 4.44 KB | 5.35 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net11.0 | pr | 5.73 us / 4.44 KB | 5.43 us / 4.44 KB | 5.38 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 8.66 us / 4.51 KB | 8.66 us / 4.51 KB | 5.69 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.91 us / 3.99 KB | 5.38 us / 3.99 KB | 5.82 us / 3.99 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | base | 5.77 us / 4.51 KB | 5.43 us / 4.51 KB | 5.46 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net11.0 | pr | 5.57 us / 3.99 KB | 5.42 us / 3.99 KB | 5.28 us / 3.99 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.09 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
