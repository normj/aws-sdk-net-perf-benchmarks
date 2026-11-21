### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `d1382bebc6b33423a0d61d1685221eb37dc2232e`
- Filter: `*PipelineBenchmarks.EndpointAuthSchemes_*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@a7197364166f8b20a133957403e53456869d2e5a`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 4/4 rows faster, 4/4 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net10.0 | 164.48 ns | 92.45 ns | 0.56 | faster | 360 B | 224 B | 0.62 | less |
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net11.0 | 164.92 ns | 85.66 ns | 0.52 | faster | 360 B | 224 B | 0.62 | less |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net10.0 | 86.44 ns | 22.77 ns | 0.26 | faster | 216 B | 0 B | 0.00 | less |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net11.0 | 87.74 ns | 21.63 ns | 0.25 | faster | 216 B | 0 B | 0.00 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net10.0 | base | 166.70 ns / 360 B | 163.57 ns / 360 B | 164.48 ns / 360 B |
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net10.0 | pr | 100.60 ns / 224 B | 88.80 ns / 224 B | 92.45 ns / 224 B |
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net11.0 | base | 164.92 ns / 360 B | 171.13 ns / 360 B | 160.15 ns / 360 B |
| PipelineBenchmarks.EndpointAuthSchemes_SigV4aAndSigV4 | net11.0 | pr | 86.37 ns / 224 B | 85.66 ns / 224 B | 85.49 ns / 224 B |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net10.0 | base | 86.44 ns / 216 B | 86.07 ns / 216 B | 89.83 ns / 216 B |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net10.0 | pr | 22.77 ns / 0 B | 22.64 ns / 0 B | 22.79 ns / 0 B |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net11.0 | base | 87.74 ns / 216 B | 97.51 ns / 216 B | 86.26 ns / 216 B |
| PipelineBenchmarks.EndpointAuthSchemes_SingleSigV4 | net11.0 | pr | 22.15 ns / 0 B | 21.62 ns / 0 B | 21.63 ns / 0 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.66 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
