### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `521d51b06ff2a9d9c0d4da9eabd3859d77c8b053`
- Filter: `*RequestSetupBenchmarks.AuthResolver*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@5f0bd7f0bebbca0d4f383128b0edbd53b6ad916c`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.6 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain time, RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain alloc, RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials time, RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials alloc, RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain time, RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain alloc, RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials time, RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.69 us | 2.41 us | 0.90 | faster | 2.19 KB | 2.05 KB | 0.94 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.06 us | 970.59 ns | 0.91 | faster | 1.83 KB | 1.69 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.58 us | 2.36 us | 0.92 | faster | 2.05 KB | 1.91 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.05 us | 924.30 ns | 0.88 | faster | 1.76 KB | 1.62 KB | 0.92 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.69 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.41 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.06 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 970.59 ns / 1.69 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.58 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.36 us / 1.91 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.05 us / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 924.30 ns / 1.62 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.05 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
