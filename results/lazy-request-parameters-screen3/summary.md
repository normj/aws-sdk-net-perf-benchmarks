### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9590fa88666310bd9c79fa94031b8e2123c9b954`
- Filter: `*RequestSetupBenchmarks.*PreInvoke*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@02e91c07b87d945b2dd936b98145d3bb0b80b361`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain alloc, RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials time, RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials alloc, RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain alloc, RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials alloc, RequestSetupBenchmarks.Marshaller_PreInvoke alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.58 us | 2.48 us | 0.96 | same | 2.19 KB | 2.02 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.09 us | 1.04 us | 0.95 | faster | 1.83 KB | 1.66 KB | 0.91 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.56 us | 2.47 us | 0.97 | same | 2.05 KB | 1.88 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.06 us | 1.02 us | 0.96 | same | 1.76 KB | 1.59 KB | 0.91 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.32 us | 1.28 us | 0.97 | same | 1.84 KB | 1.67 KB | 0.91 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.58 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.48 us / 2.02 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.09 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 1.04 us / 1.66 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.56 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.47 us / 1.88 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.06 us / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 1.02 us / 1.59 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.32 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.28 us / 1.67 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
