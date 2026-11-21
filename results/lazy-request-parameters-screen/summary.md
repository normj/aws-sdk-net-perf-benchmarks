### BenchmarkDotNet A/B screening run (not for PR numbers)

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9590fa88666310bd9c79fa94031b8e2123c9b954`
- Filter: `*Invoke*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@02e91c07b87d945b2dd936b98145d3bb0b80b361`
- 1 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.4 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** NOT PROMISING: a row regressed.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 16.24 us | 30.64 us | 1.89 | **slower** | 11.77 KB | 11.55 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 27.66 us | 35.14 us | 1.27 | **slower** | 13.04 KB | 12.82 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 284.03 us | 290.64 us | 1.02 | same | 108.48 KB | 108.27 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.78 us | 18.29 us | 1.33 | **slower** | 10.51 KB | 10.29 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 59.46 us | 67.93 us | 1.14 | **slower** | 44.31 KB | 44.02 KB | 0.99 | same |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.95 us | 2.70 us | 0.91 | faster | 2.19 KB | 2.02 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.10 us | 1.06 us | 0.97 | same | 1.83 KB | 1.66 KB | 0.91 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.88 us | 2.57 us | 0.89 | faster | 2.05 KB | 1.88 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.04 us | 1.06 us | 1.02 | same | 1.76 KB | 1.59 KB | 0.91 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.44 us | 1.30 us | 0.90 | faster | 1.84 KB | 1.67 KB | 0.91 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 23.86 us | 22.73 us | 0.95 | same | 16.23 KB | 16.01 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 25.14 us | 19.71 us | 0.78 | faster | 14.89 KB | 14.67 KB | 0.99 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 |
|---|---|---|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 16.24 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 30.64 us / 11.55 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 27.66 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 35.14 us / 12.82 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 284.03 us / 108.48 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 290.64 us / 108.27 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.78 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 18.29 us / 10.29 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 59.46 us / 44.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 67.93 us / 44.02 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.95 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.70 us / 2.02 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.10 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 1.06 us / 1.66 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.88 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.57 us / 1.88 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.04 us / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 1.06 us / 1.59 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.44 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.30 us / 1.67 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 23.86 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 22.73 us / 16.01 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 25.14 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 19.71 us / 14.67 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.15 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2
```

</details>
