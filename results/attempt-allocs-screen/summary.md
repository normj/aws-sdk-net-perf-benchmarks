### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `58e19a7bd55d157e94d34a88b39bddba8c8cb39f`
- Filter: `*PipelineBenchmarks.Invoke*JsonPost*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a4fc535793abb687385c053800ea852ceb6675a1`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.InvokeAsync_JsonPost alloc, PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding time, PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding alloc, PipelineBenchmarks.InvokeAsync_JsonPost_Yielding alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.26 us | 15.66 us | 1.03 | same | 11.77 KB | 11.61 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 26.20 us | 24.27 us | 0.93 | faster | 14.72 KB | 14.55 KB | 0.99 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.19 us | 22.51 us | 1.01 | same | 13.04 KB | 12.87 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.14 us | 13.25 us | 1.01 | same | 10.51 KB | 10.41 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.33 us | 15.00 us | 0.98 | same | 12.19 KB | 12.09 KB | 0.99 | same |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.40 us / 11.77 KB | 15.12 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.77 us / 11.61 KB | 15.54 us / 11.61 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 26.80 us / 14.72 KB | 25.60 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 24.15 us / 14.55 KB | 24.40 us / 14.55 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 21.81 us / 13.04 KB | 22.57 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.31 us / 12.87 KB | 21.72 us / 12.87 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.20 us / 10.51 KB | 13.08 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.43 us / 10.41 KB | 13.07 us / 10.41 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 15.97 us / 12.19 KB | 14.69 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 15.23 us / 12.09 KB | 14.78 us / 12.09 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
