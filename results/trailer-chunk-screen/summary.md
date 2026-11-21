### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `2580be3a30c7d572a0915d56d1d030e154213a62`
- Filter: `*SigningBenchmarks.ChunkedUpload*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@47588afb2a861a099dbfa1c270fbda311984485a`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: SigningBenchmarks.ChunkedUpload_1MB alloc, SigningBenchmarks.ChunkedUpload_4KB alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| SigningBenchmarks.ChunkedUpload_1MB | net10.0 | 1.01 ms | 1.02 ms | 1.00 | same | 187.15 KB | 185.24 KB | 0.99 | less |
| SigningBenchmarks.ChunkedUpload_4KB | net10.0 | 13.55 us | 13.09 us | 0.97 | same | 14.99 KB | 13.08 KB | 0.87 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| SigningBenchmarks.ChunkedUpload_1MB | net10.0 | base | 1.01 ms / 187.15 KB |
| SigningBenchmarks.ChunkedUpload_1MB | net10.0 | pr | 1.02 ms / 185.24 KB |
| SigningBenchmarks.ChunkedUpload_4KB | net10.0 | base | 13.55 us / 14.99 KB |
| SigningBenchmarks.ChunkedUpload_4KB | net10.0 | pr | 13.09 us / 13.08 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
