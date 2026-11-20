### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `95d783446692fb6ae8ff424b0b45173ad4523603`
- Filter: `*PipelineBenchmarks*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@6a5b1db5aeef9039ca9287fb1a6b7d78b7b2943c`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeAsync_JsonPost alloc, PipelineBenchmarks.InvokeAsync_JsonPost_Yielding alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 16.51 us | 16.62 us | 1.01 | same | 11.77 KB | 11.49 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 29.54 us | 28.18 us | 0.95 | same | 13.04 KB | 12.54 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 14.61 us | 14.46 us | 0.99 | same | 10.51 KB | 10.51 KB | 1.00 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 16.51 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 16.62 us / 11.49 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 29.54 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 28.18 us / 12.54 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 14.61 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 14.46 us / 10.51 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.27 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
