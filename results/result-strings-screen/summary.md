### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d5b30f35c83d9bbf80c0aa139ed8dafcb20e7921`
- Filter: `*SigningBenchmarks.*Sign*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@737cb3b9091357f499c6b92d8dcd19c5df003035`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: SigningBenchmarks.Presign_S3GetObject time, SigningBenchmarks.Presign_S3GetObject alloc, SigningBenchmarks.Sign_JsonPost alloc, SigningBenchmarks.Sign_RestJsonPathResources alloc, SigningBenchmarks.Sign_S3GetObjectKey alloc, SigningBenchmarks.Sign_S3GetWithQuery alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | 6.55 us | 5.88 us | 0.90 | faster | 7.16 KB | 6.01 KB | 0.84 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.29 us | 6.27 us | 1.00 | same | 4.29 KB | 4.14 KB | 0.97 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.86 us | 6.83 us | 1.00 | same | 5.40 KB | 5.25 KB | 0.97 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.57 us | 5.45 us | 0.98 | same | 4.44 KB | 4.29 KB | 0.97 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 5.77 us | 5.68 us | 0.98 | same | 4.51 KB | 4.36 KB | 0.97 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.Presign_S3GetObject | net10.0 | base | 6.55 us / 7.16 KB |
| SigningBenchmarks.Presign_S3GetObject | net10.0 | pr | 5.88 us / 6.01 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.29 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 6.27 us / 4.14 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.86 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.83 us / 5.25 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.57 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.45 us / 4.29 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 5.77 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.68 us / 4.36 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.17 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
