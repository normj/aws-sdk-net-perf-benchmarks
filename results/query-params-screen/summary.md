### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `0ce114a2c17da19a068f8f579b472d79632fffc8`
- Filter: `*SigningBenchmarks.*S3Get*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: SigningBenchmarks.Presign_S3GetObject alloc, SigningBenchmarks.Sign_S3GetWithQuery alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.52 us | 6.63 us | 1.02 | same | 7.16 KB | 6.82 KB | 0.95 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.35 us | 5.40 us | 1.01 | same | 4.44 KB | 4.44 KB | 1.00 | same |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.60 us | 5.38 us | 0.96 | same | 4.51 KB | 3.99 KB | 0.89 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.52 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.63 us / 6.82 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.35 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.40 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.60 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.38 us / 3.99 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
