### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `7a948a285bdc66335cefbaa782bc7ede915c2ccc`
- Filter: `*RequestSetupBenchmarks.*DefaultChain*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@949b93c3249c21567580885295d2c4d10613b8be`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.0 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** PROMISING, run the full A/B: RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain alloc, RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain time, RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain alloc, RequestSetupBenchmarks.DefaultChain_ResolveIdentity time, RequestSetupBenchmarks.DefaultChain_ResolveIdentity alloc, RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync alloc.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.45 us | 2.42 us | 0.99 | same | 2.19 KB | 2.05 KB | 0.94 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.43 us | 2.30 us | 0.95 | faster | 2.05 KB | 1.91 KB | 0.93 | less |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | 1.18 us | 1.08 us | 0.92 | faster | 296 B | 152 B | 0.51 | less |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | 1.15 us | 1.10 us | 0.96 | same | 368 B | 224 B | 0.61 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.45 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.42 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.43 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.30 us / 1.91 KB |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | base | 1.18 us / 296 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentity | net10.0 | pr | 1.08 us / 152 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | base | 1.15 us / 368 B |
| RequestSetupBenchmarks.DefaultChain_ResolveIdentityAsync | net10.0 | pr | 1.10 us / 224 B |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
