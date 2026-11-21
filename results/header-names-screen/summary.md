### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `321ec6ee997ee0dcf4ca9d3827c01e9030db7685`
- Filter: `*SigningBenchmarks.*Sign*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@737cb3b9091357f499c6b92d8dcd19c5df003035`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 0.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.58 us | 6.48 us | 0.98 | same | 7.16 KB | 7.10 KB | 0.99 | same |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.09 us | 5.93 us | 0.97 | same | 4.29 KB | 3.91 KB | 0.91 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.78 us | 7.85 us | 1.16 | **slower** | 5.40 KB | 5.07 KB | 0.94 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.46 us | 5.40 us | 0.99 | same | 4.44 KB | 4.21 KB | 0.95 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.68 us | 5.54 us | 0.97 | same | 4.51 KB | 4.28 KB | 0.95 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.58 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 6.48 us / 7.10 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.09 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.93 us / 3.91 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.78 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 7.85 us / 5.07 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.46 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.40 us / 4.21 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.68 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.54 us / 4.28 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.26 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
