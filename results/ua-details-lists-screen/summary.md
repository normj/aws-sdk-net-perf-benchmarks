### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `cc07ddc10855695c8db10c29316b4da1e6d867fd`
- Filter: `*RequestSetupBenchmarks.*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@d19cdf3c69fc618f5cbda00afc4ab20bde761d08`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain alloc, RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials alloc, RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain alloc, RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials alloc, RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync time, RequestSetupBenchmarks.Marshaller_PreInvoke alloc, RequestSetupBenchmarks.UserAgentDetails_Build time, RequestSetupBenchmarks.UserAgentDetails_Build alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.62 us | 2.54 us | 0.97 | same | 2.19 KB | 2.04 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.05 us | 1.06 us | 1.01 | same | 1.83 KB | 1.68 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.53 us | 2.56 us | 1.01 | same | 2.05 KB | 1.90 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.00 us | 1.03 us | 1.03 | same | 1.76 KB | 1.61 KB | 0.92 | less |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | 1.19 us | 1.18 us | 0.99 | same | 296 B | 296 B | 1.00 | same |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | 1.24 us | 1.17 us | 0.95 | faster | 368 B | 368 B | 1.00 | same |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.25 us | 1.20 us | 0.96 | same | 1.84 KB | 1.66 KB | 0.91 | less |
| RequestSetupBenchmarks.UserAgentDetails_Build | net10.0 | 244.15 ns | 85.29 ns | 0.35 | faster | 576 B | 208 B | 0.36 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.62 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.54 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.05 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 1.06 us / 1.68 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.53 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.56 us / 1.90 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.00 us / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 1.03 us / 1.61 KB |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | base | 1.19 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | pr | 1.18 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | base | 1.24 us / 368 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | pr | 1.17 us / 368 B |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.25 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.20 us / 1.66 KB |
| RequestSetupBenchmarks.UserAgentDetails_Build | net10.0 | base | 244.15 ns / 576 B |
| RequestSetupBenchmarks.UserAgentDetails_Build | net10.0 | pr | 85.29 ns / 208 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
