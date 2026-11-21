### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9916a56133dbd6ea22119f19dfbb740b8c2e0a1e`
- Filter: `*SigningBenchmarks.*Pooled*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@02e91c07b87d945b2dd936b98145d3bb0b80b361`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.3 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: SigningBenchmarks.ContentStreamHash_PooledJson time, SigningBenchmarks.ContentStreamHash_PooledJson alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | 878.56 ns | 696.47 ns | 0.79 | faster | 1.25 KB | 1.20 KB | 0.96 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | 6.91 us | 6.58 us | 0.95 | same | 6.17 KB | 6.12 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | base | 878.56 ns / 1.25 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | pr | 696.47 ns / 1.20 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | base | 6.91 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | pr | 6.58 us / 6.12 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
