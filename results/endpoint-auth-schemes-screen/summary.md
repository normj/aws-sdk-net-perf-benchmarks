### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d1382bebc6b33423a0d61d1685221eb37dc2232e`
- Filter: `*PipelineBenchmarks.EndpointAuthSchemes_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a7197364166f8b20a133957403e53456869d2e5a`
- 2 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 time, PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 alloc, PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 time, PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net10.0 | 167.98 ns | 93.78 ns | 0.56 | faster | 360 B | 224 B | 0.62 | less |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net10.0 | 88.89 ns | 23.18 ns | 0.26 | faster | 216 B | 0 B | 0.00 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 |
|---|---|---|---:|---:|
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net10.0 | base | 170.57 ns / 360 B | 165.39 ns / 360 B |
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net10.0 | pr | 91.07 ns / 224 B | 96.50 ns / 224 B |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net10.0 | base | 87.55 ns / 216 B | 90.23 ns / 216 B |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net10.0 | pr | 23.46 ns / 0 B | 22.89 ns / 0 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
