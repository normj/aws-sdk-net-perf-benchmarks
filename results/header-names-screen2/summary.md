### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `321ec6ee997ee0dcf4ca9d3827c01e9030db7685`
- Filter: `*SigningBenchmarks.Sign_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: SigningBenchmarks.Sign_JsonPost time, SigningBenchmarks.Sign_JsonPost alloc, SigningBenchmarks.Sign_RestJsonPathResources time, SigningBenchmarks.Sign_RestJsonPathResources alloc, SigningBenchmarks.Sign_S3GetObjectKey time, SigningBenchmarks.Sign_S3GetObjectKey alloc, SigningBenchmarks.Sign_S3GetWithQuery time, SigningBenchmarks.Sign_S3GetWithQuery alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.Sign_JsonPost | net10.0 | 7.43 us | 5.99 us | 0.81 | faster | 4.29 KB | 3.91 KB | 0.91 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 7.07 us | 6.67 us | 0.94 | faster | 5.40 KB | 5.07 KB | 0.94 | less |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | 5.82 us | 5.34 us | 0.92 | faster | 4.44 KB | 4.21 KB | 0.95 | less |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | 6.11 us | 5.67 us | 0.93 | faster | 4.51 KB | 4.28 KB | 0.95 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 7.43 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 5.99 us / 3.91 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 7.07 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.67 us / 5.07 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | base | 5.82 us / 4.44 KB |
| SigningBenchmarks.Sign_S3GetObjectKey | net10.0 | pr | 5.34 us / 4.21 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | base | 6.11 us / 4.51 KB |
| SigningBenchmarks.Sign_S3GetWithQuery | net10.0 | pr | 5.67 us / 4.28 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
