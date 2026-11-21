### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `cc07ddc10855695c8db10c29316b4da1e6d867fd`
- Filter: `*RequestSetupBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.7 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 3/16 rows faster, 12/16 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.55 us | 2.46 us | 0.97 | same | 2.19 KB | 2.04 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | 2.44 us | 2.47 us | 1.01 | same | 2.18 KB | 2.03 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.05 us | 1.01 us | 0.96 | same | 1.83 KB | 1.68 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | 899.08 ns | 872.22 ns | 0.97 | same | 1.82 KB | 1.67 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.42 us | 2.39 us | 0.99 | same | 2.05 KB | 1.90 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | 2.48 us | 2.36 us | 0.95 | same | 2.04 KB | 1.89 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.00 us | 975.94 ns | 0.97 | same | 1.76 KB | 1.61 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | 883.75 ns | 835.82 ns | 0.95 | same | 1.75 KB | 1.60 KB | 0.92 | less |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | 1.18 us | 1.17 us | 0.99 | same | 296 B | 296 B | 1.00 | same |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net11.0 | 1.21 us | 1.23 us | 1.02 | same | 296 B | 296 B | 1.00 | same |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | 1.16 us | 1.16 us | 1.00 | same | 368 B | 368 B | 1.00 | same |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net11.0 | 1.20 us | 1.21 us | 1.01 | same | 368 B | 368 B | 1.00 | same |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.24 us | 1.13 us | 0.91 | same | 1.84 KB | 1.66 KB | 0.91 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | 1.09 us | 979.41 ns | 0.90 | faster | 1.84 KB | 1.66 KB | 0.91 | less |
| RequestSetupBenchmarks.UserAgentDetails_Build | net10.0 | 219.41 ns | 79.32 ns | 0.36 | faster | 576 B | 208 B | 0.36 | less |
| RequestSetupBenchmarks.UserAgentDetails_Build | net11.0 | 217.38 ns | 75.33 ns | 0.35 | faster | 576 B | 208 B | 0.36 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.55 us / 2.19 KB | 2.55 us / 2.19 KB | 2.47 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.46 us / 2.04 KB | 2.45 us / 2.04 KB | 2.53 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | base | 2.44 us / 2.18 KB | 2.42 us / 2.18 KB | 2.95 us / 2.18 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | pr | 2.47 us / 2.03 KB | 2.42 us / 2.03 KB | 2.47 us / 2.03 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.05 us / 1.83 KB | 1.03 us / 1.83 KB | 1.06 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 996.53 ns / 1.68 KB | 1.01 us / 1.68 KB | 1.01 us / 1.68 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | base | 899.08 ns / 1.82 KB | 872.31 ns / 1.82 KB | 913.50 ns / 1.82 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | pr | 872.22 ns / 1.67 KB | 859.09 ns / 1.67 KB | 965.56 ns / 1.67 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.42 us / 2.05 KB | 2.42 us / 2.05 KB | 2.36 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.39 us / 1.90 KB | 2.37 us / 1.90 KB | 2.75 us / 1.90 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | base | 2.48 us / 2.04 KB | 2.32 us / 2.04 KB | 2.51 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | pr | 2.36 us / 1.89 KB | 2.35 us / 1.89 KB | 2.36 us / 1.89 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.05 us / 1.76 KB | 995.22 ns / 1.76 KB | 1.00 us / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 975.94 ns / 1.61 KB | 964.56 ns / 1.61 KB | 1.00 us / 1.61 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | base | 883.75 ns / 1.75 KB | 849.83 ns / 1.75 KB | 910.76 ns / 1.75 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | pr | 835.82 ns / 1.60 KB | 827.14 ns / 1.60 KB | 945.20 ns / 1.60 KB |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | base | 1.18 us / 296 B | 1.18 us / 296 B | 1.16 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | pr | 1.16 us / 296 B | 1.17 us / 296 B | 1.18 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net11.0 | base | 1.20 us / 296 B | 1.21 us / 296 B | 1.28 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net11.0 | pr | 1.23 us / 296 B | 1.21 us / 296 B | 1.25 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | base | 1.18 us / 368 B | 1.16 us / 368 B | 1.14 us / 368 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | pr | 1.15 us / 368 B | 1.16 us / 368 B | 1.18 us / 368 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net11.0 | base | 1.20 us / 368 B | 1.20 us / 368 B | 1.27 us / 368 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net11.0 | pr | 1.21 us / 368 B | 1.20 us / 368 B | 1.97 us / 368 B |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.29 us / 1.84 KB | 1.23 us / 1.84 KB | 1.24 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.10 us / 1.66 KB | 1.13 us / 1.66 KB | 1.38 us / 1.66 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | base | 1.09 us / 1.84 KB | 1.07 us / 1.84 KB | 1.13 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | pr | 979.41 ns / 1.66 KB | 968.88 ns / 1.66 KB | 1.05 us / 1.66 KB |
| RequestSetupBenchmarks.UserAgentDetails_Build | net10.0 | base | 217.27 ns / 576 B | 220.36 ns / 576 B | 219.41 ns / 576 B |
| RequestSetupBenchmarks.UserAgentDetails_Build | net10.0 | pr | 79.32 ns / 208 B | 76.56 ns / 208 B | 86.65 ns / 208 B |
| RequestSetupBenchmarks.UserAgentDetails_Build | net11.0 | base | 214.97 ns / 576 B | 217.38 ns / 576 B | 262.69 ns / 576 B |
| RequestSetupBenchmarks.UserAgentDetails_Build | net11.0 | pr | 74.02 ns / 208 B | 75.33 ns / 208 B | 134.69 ns / 208 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.97 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.97 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
