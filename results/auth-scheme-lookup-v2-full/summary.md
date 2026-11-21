### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9f4a221d0363123ae81e1b64d3584e8df5e29d20`
- Filter: `*RequestSetupBenchmarks.AuthResolver*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@5f0bd7f0bebbca0d4f383128b0edbd53b6ad916c`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 2.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/8 rows faster, 8/8 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.62 us | 2.52 us | 0.96 | same | 2.19 KB | 2.05 KB | 0.94 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | 2.47 us | 2.46 us | 0.99 | same | 2.18 KB | 2.05 KB | 0.94 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.14 us | 1.03 us | 0.91 | same | 1.83 KB | 1.69 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | 913.98 ns | 906.36 ns | 0.99 | same | 1.82 KB | 1.69 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.49 us | 2.47 us | 0.99 | same | 2.05 KB | 1.91 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | 3.22 us | 2.42 us | 0.75 | same | 2.04 KB | 1.91 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.06 us | 978.53 ns | 0.93 | same | 1.76 KB | 1.62 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | 885.50 ns | 821.64 ns | 0.93 | faster | 1.75 KB | 1.62 KB | 0.92 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.53 us / 2.19 KB | 2.62 us / 2.19 KB | 3.78 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.63 us / 2.05 KB | 2.40 us / 2.05 KB | 2.52 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | base | 2.47 us / 2.18 KB | 2.47 us / 2.18 KB | 2.57 us / 2.18 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | pr | 2.39 us / 2.05 KB | 2.46 us / 2.05 KB | 2.54 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.09 us / 1.83 KB | 1.44 us / 1.83 KB | 1.14 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 1.03 us / 1.69 KB | 979.37 ns / 1.69 KB | 1.10 us / 1.69 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | base | 1.36 us / 1.82 KB | 913.98 ns / 1.82 KB | 913.34 ns / 1.82 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | pr | 906.36 ns / 1.69 KB | 875.51 ns / 1.69 KB | 920.06 ns / 1.69 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.49 us / 2.05 KB | 2.48 us / 2.05 KB | 2.97 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.58 us / 1.91 KB | 2.31 us / 1.91 KB | 2.47 us / 1.91 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | base | 3.31 us / 2.04 KB | 3.22 us / 2.04 KB | 2.44 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | pr | 2.42 us / 1.91 KB | 2.39 us / 1.91 KB | 2.45 us / 1.91 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.06 us / 1.76 KB | 1.02 us / 1.76 KB | 1.12 us / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 978.53 ns / 1.62 KB | 924.49 ns / 1.62 KB | 1.03 us / 1.62 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | base | 885.45 ns / 1.75 KB | 885.50 ns / 1.75 KB | 923.03 ns / 1.75 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | pr | 821.64 ns / 1.62 KB | 812.24 ns / 1.62 KB | 859.75 ns / 1.62 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.1 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
