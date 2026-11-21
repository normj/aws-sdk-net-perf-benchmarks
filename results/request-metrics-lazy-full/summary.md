### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `65a0d1bdc13f517919eef53a947380fddb9c41a0`
- Filter: `*RequestSetupBenchmarks.*PreInvoke*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@02e91c07b87d945b2dd936b98145d3bb0b80b361`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.8 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 0/10 rows faster, 10/10 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.53 us | 2.65 us | 1.04 | same | 2.19 KB | 2.13 KB | 0.97 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | 3.28 us | 2.42 us | 0.74 | same | 2.18 KB | 2.12 KB | 0.97 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.08 us | 1.07 us | 0.99 | same | 1.83 KB | 1.77 KB | 0.97 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | 931.66 ns | 885.97 ns | 0.95 | same | 1.82 KB | 1.77 KB | 0.97 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.43 us | 2.47 us | 1.02 | same | 2.05 KB | 1.99 KB | 0.97 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | 3.09 us | 2.37 us | 0.77 | same | 2.04 KB | 1.98 KB | 0.97 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 999.23 ns | 975.41 ns | 0.98 | same | 1.76 KB | 1.70 KB | 0.97 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | 881.74 ns | 842.06 ns | 0.96 | same | 1.75 KB | 1.70 KB | 0.97 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.23 us | 1.22 us | 0.99 | same | 1.84 KB | 1.78 KB | 0.97 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | 1.11 us | 1.07 us | 0.96 | same | 1.84 KB | 1.78 KB | 0.97 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.59 us / 2.19 KB | 2.53 us / 2.19 KB | 2.46 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 3.42 us / 2.13 KB | 2.52 us / 2.13 KB | 2.65 us / 2.13 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | base | 3.94 us / 2.18 KB | 3.28 us / 2.18 KB | 2.47 us / 2.18 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | pr | 2.40 us / 2.12 KB | 2.42 us / 2.12 KB | 2.57 us / 2.12 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.08 us / 1.83 KB | 1.08 us / 1.83 KB | 1.03 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 1.18 us / 1.77 KB | 1.02 us / 1.77 KB | 1.07 us / 1.77 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | base | 1.27 us / 1.82 KB | 931.66 ns / 1.82 KB | 906.33 ns / 1.82 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | pr | 885.97 ns / 1.77 KB | 875.69 ns / 1.77 KB | 1.01 us / 1.77 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.53 us / 2.05 KB | 2.43 us / 2.05 KB | 2.40 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.59 us / 1.99 KB | 2.44 us / 1.99 KB | 2.47 us / 1.99 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | base | 4.35 us / 2.04 KB | 3.09 us / 2.04 KB | 2.44 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | pr | 2.33 us / 1.98 KB | 2.37 us / 1.98 KB | 2.46 us / 1.98 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.04 us / 1.76 KB | 985.27 ns / 1.76 KB | 999.23 ns / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 1.42 us / 1.70 KB | 975.41 ns / 1.70 KB | 921.99 ns / 1.70 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | base | 893.10 ns / 1.75 KB | 881.74 ns / 1.75 KB | 863.96 ns / 1.75 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | pr | 842.06 ns / 1.70 KB | 839.13 ns / 1.70 KB | 944.71 ns / 1.70 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.28 us / 1.84 KB | 1.21 us / 1.84 KB | 1.23 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.25 us / 1.78 KB | 1.22 us / 1.78 KB | 1.14 us / 1.78 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | base | 1.11 us / 1.84 KB | 1.09 us / 1.84 KB | 1.11 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | pr | 1.06 us / 1.78 KB | 1.07 us / 1.78 KB | 1.17 us / 1.78 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
