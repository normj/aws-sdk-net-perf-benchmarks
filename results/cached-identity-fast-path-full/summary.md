### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `7a948a285bdc66335cefbaa782bc7ede915c2ccc`
- Filter: `*RequestSetupBenchmarks.*DefaultChain*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.5 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 5/8 rows faster, 8/8 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.49 us | 2.44 us | 0.98 | same | 2.19 KB | 2.05 KB | 0.94 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | 2.46 us | 2.31 us | 0.94 | faster | 2.18 KB | 2.04 KB | 0.94 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.40 us | 2.38 us | 0.99 | same | 2.05 KB | 1.91 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | 2.37 us | 2.25 us | 0.95 | same | 2.04 KB | 1.90 KB | 0.93 | less |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | 1.17 us | 1.07 us | 0.91 | faster | 296 B | 152 B | 0.51 | less |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net11.0 | 1.23 us | 1.09 us | 0.89 | faster | 296 B | 152 B | 0.51 | less |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | 1.17 us | 1.09 us | 0.93 | faster | 368 B | 224 B | 0.61 | less |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net11.0 | 1.22 us | 1.12 us | 0.91 | faster | 368 B | 224 B | 0.61 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.49 us / 2.19 KB | 2.52 us / 2.19 KB | 2.40 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.44 us / 2.05 KB | 2.45 us / 2.05 KB | 2.35 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | base | 2.46 us / 2.18 KB | 2.47 us / 2.18 KB | 2.42 us / 2.18 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | pr | 2.39 us / 2.04 KB | 2.31 us / 2.04 KB | 2.24 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.40 us / 2.05 KB | 2.48 us / 2.05 KB | 2.38 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.38 us / 1.91 KB | 2.41 us / 1.91 KB | 2.32 us / 1.91 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | base | 2.37 us / 2.04 KB | 2.43 us / 2.04 KB | 2.32 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | pr | 2.34 us / 1.90 KB | 2.25 us / 1.90 KB | 2.18 us / 1.90 KB |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | base | 1.17 us / 296 B | 1.19 us / 296 B | 1.16 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | pr | 1.07 us / 152 B | 1.09 us / 152 B | 1.06 us / 152 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net11.0 | base | 1.23 us / 296 B | 1.28 us / 296 B | 1.20 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net11.0 | pr | 1.11 us / 152 B | 1.09 us / 152 B | 1.08 us / 152 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | base | 1.18 us / 368 B | 1.17 us / 368 B | 1.15 us / 368 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | pr | 1.09 us / 224 B | 1.12 us / 224 B | 1.07 us / 224 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net11.0 | base | 1.22 us / 368 B | 1.22 us / 368 B | 1.20 us / 368 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net11.0 | pr | 1.16 us / 224 B | 1.11 us / 224 B | 1.12 us / 224 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.91 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
