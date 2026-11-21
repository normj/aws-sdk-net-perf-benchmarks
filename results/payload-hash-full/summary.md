### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9916a56133dbd6ea22119f19dfbb740b8c2e0a1e`
- Filter: `*SigningBenchmarks.*Json*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@cee7391b597f9cbd78607fd34b70624136fab65d`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/10 rows faster, 6/10 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | 713.56 ns | 718.13 ns | 1.01 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | 685.88 ns | 690.38 ns | 1.01 | same | 1.27 KB | 1.27 KB | 1.00 | same |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | 967.54 ns | 728.65 ns | 0.75 | faster | 1.25 KB | 1.20 KB | 0.96 | less |
| SigningBenchmarks.ContentStreamHash_PooledJson | net11.0 | 1.02 us | 675.81 ns | 0.67 | faster | 1.25 KB | 1.20 KB | 0.96 | less |
| SigningBenchmarks.Sign_JsonPost | net10.0 | 6.16 us | 6.17 us | 1.00 | same | 4.29 KB | 4.18 KB | 0.97 | less |
| SigningBenchmarks.Sign_JsonPost | net11.0 | 6.19 us | 6.19 us | 1.00 | same | 4.29 KB | 4.18 KB | 0.97 | less |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | 7.05 us | 6.92 us | 0.98 | same | 6.17 KB | 6.12 KB | 0.99 | same |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | 6.91 us | 6.62 us | 0.96 | same | 6.17 KB | 6.12 KB | 0.99 | same |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | 6.82 us | 6.76 us | 0.99 | same | 5.40 KB | 5.29 KB | 0.98 | less |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | 6.79 us | 6.70 us | 0.99 | same | 5.40 KB | 5.29 KB | 0.98 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | base | 713.56 ns / 1.27 KB | 743.70 ns / 1.27 KB | 690.92 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net10.0 | pr | 741.62 ns / 1.27 KB | 718.13 ns / 1.27 KB | 703.91 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | base | 706.77 ns / 1.27 KB | 685.88 ns / 1.27 KB | 665.26 ns / 1.27 KB |
| SigningBenchmarks.CanonicalizeResourcePath_RestJson | net11.0 | pr | 672.11 ns / 1.27 KB | 690.38 ns / 1.27 KB | 936.51 ns / 1.27 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | base | 967.54 ns / 1.25 KB | 1.35 us / 1.25 KB | 891.99 ns / 1.25 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net10.0 | pr | 718.55 ns / 1.20 KB | 728.65 ns / 1.20 KB | 748.83 ns / 1.20 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net11.0 | base | 1.44 us / 1.25 KB | 1.02 us / 1.25 KB | 866.76 ns / 1.25 KB |
| SigningBenchmarks.ContentStreamHash_PooledJson | net11.0 | pr | 700.65 ns / 1.20 KB | 674.12 ns / 1.20 KB | 675.81 ns / 1.20 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | base | 6.16 us / 4.29 KB | 6.22 us / 4.29 KB | 6.00 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net10.0 | pr | 6.29 us / 4.18 KB | 6.00 us / 4.18 KB | 6.17 us / 4.18 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | base | 6.30 us / 4.29 KB | 6.19 us / 4.29 KB | 6.05 us / 4.29 KB |
| SigningBenchmarks.Sign_JsonPost | net11.0 | pr | 7.95 us / 4.18 KB | 5.91 us / 4.18 KB | 6.19 us / 4.18 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | base | 7.05 us / 6.17 KB | 7.15 us / 6.17 KB | 6.89 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net10.0 | pr | 7.07 us / 6.12 KB | 6.92 us / 6.12 KB | 6.76 us / 6.12 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | base | 6.91 us / 6.17 KB | 7.21 us / 6.17 KB | 6.78 us / 6.17 KB |
| SigningBenchmarks.Sign_JsonPostPooledBody | net11.0 | pr | 6.62 us / 6.12 KB | 6.59 us / 6.12 KB | 6.67 us / 6.12 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | base | 6.87 us / 5.40 KB | 6.82 us / 5.40 KB | 6.63 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net10.0 | pr | 6.77 us / 5.29 KB | 6.75 us / 5.29 KB | 6.76 us / 5.29 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | base | 7.04 us / 5.40 KB | 6.79 us / 5.40 KB | 6.68 us / 5.40 KB |
| SigningBenchmarks.Sign_RestJsonPathResources | net11.0 | pr | 6.70 us / 5.29 KB | 6.58 us / 5.29 KB | 6.78 us / 5.29 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
