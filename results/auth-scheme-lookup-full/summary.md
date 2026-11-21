### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `521d51b06ff2a9d9c0d4da9eabd3859d77c8b053`
- Filter: `*RequestSetupBenchmarks.AuthResolver*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@dc031a7c227c8cf6d93b66123b0451aea064ea0c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.4 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 2/8 rows faster, 8/8 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.49 us | 2.40 us | 0.96 | same | 2.19 KB | 2.05 KB | 0.94 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | 2.44 us | 2.37 us | 0.97 | same | 2.18 KB | 2.05 KB | 0.94 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.05 us | 1.01 us | 0.96 | same | 1.83 KB | 1.69 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | 919.40 ns | 850.69 ns | 0.93 | faster | 1.82 KB | 1.69 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.40 us | 2.47 us | 1.03 | same | 2.05 KB | 1.91 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | 2.34 us | 2.33 us | 0.99 | same | 2.04 KB | 1.91 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.00 us | 971.18 ns | 0.97 | same | 1.76 KB | 1.62 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | 886.60 ns | 801.41 ns | 0.90 | faster | 1.75 KB | 1.62 KB | 0.92 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.49 us / 2.19 KB | 2.59 us / 2.19 KB | 2.47 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.50 us / 2.05 KB | 2.40 us / 2.05 KB | 2.37 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | base | 2.44 us / 2.18 KB | 2.47 us / 2.18 KB | 2.40 us / 2.18 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | pr | 2.45 us / 2.05 KB | 2.32 us / 2.05 KB | 2.37 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.14 us / 1.83 KB | 1.05 us / 1.83 KB | 1.03 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 1.05 us / 1.69 KB | 1.01 us / 1.69 KB | 981.72 ns / 1.69 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | base | 919.40 ns / 1.82 KB | 903.60 ns / 1.82 KB | 927.33 ns / 1.82 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | pr | 896.71 ns / 1.69 KB | 843.48 ns / 1.69 KB | 850.69 ns / 1.69 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.40 us / 2.05 KB | 2.48 us / 2.05 KB | 2.37 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.47 us / 1.91 KB | 2.52 us / 1.91 KB | 2.35 us / 1.91 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | base | 2.42 us / 2.04 KB | 2.33 us / 2.04 KB | 2.34 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | pr | 2.35 us / 1.91 KB | 2.33 us / 1.91 KB | 2.29 us / 1.91 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.02 us / 1.76 KB | 1.00 us / 1.76 KB | 999.39 ns / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 971.18 ns / 1.62 KB | 1.01 us / 1.62 KB | 932.84 ns / 1.62 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | base | 852.45 ns / 1.75 KB | 896.78 ns / 1.75 KB | 886.60 ns / 1.75 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | pr | 845.15 ns / 1.62 KB | 799.85 ns / 1.62 KB | 801.41 ns / 1.62 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
