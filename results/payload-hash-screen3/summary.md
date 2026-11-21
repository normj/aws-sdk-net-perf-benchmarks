### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9916a56133dbd6ea22119f19dfbb740b8c2e0a1e`
- Filter: `*SigningBenchmarks.*Json*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@02e91c07b87d945b2dd936b98145d3bb0b80b361`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | 765.85 ns | 820.56 ns | 1.07 | **slower** | 1.27 KB | 1.27 KB | 1.00 | same |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | 920.61 ns | 740.28 ns | 0.80 | faster | 1.25 KB | 1.20 KB | 0.96 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.42 us | 6.30 us | 0.98 | same | 4.29 KB | 4.18 KB | 0.97 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | 7.49 us | 7.09 us | 0.95 | faster | 6.17 KB | 6.12 KB | 0.99 | same |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 7.18 us | 6.88 us | 0.96 | same | 5.40 KB | 5.29 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | base | 765.85 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | pr | 820.56 ns / 1.27 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | base | 920.61 ns / 1.25 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | pr | 740.28 ns / 1.20 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.42 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 6.30 us / 4.18 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | base | 7.49 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | pr | 7.09 us / 6.12 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 7.18 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.88 us / 5.29 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.43GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.47 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
