### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `9590fa88666310bd9c79fa94031b8e2123c9b954`
- Filter: `*Invoke*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@02e91c07b87d945b2dd936b98145d3bb0b80b361`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.2 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 1/24 rows faster, 20/24 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.58 us | 15.43 us | 0.99 | same | 11.77 KB | 11.55 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.29 us | 13.95 us | 0.98 | same | 11.77 KB | 11.55 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.35 us | 22.05 us | 0.99 | same | 13.04 KB | 12.82 KB | 0.98 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 20.66 us | 18.99 us | 0.92 | same | 12.04 KB | 11.70 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 251.42 us | 250.48 us | 1.00 | same | 108.46 KB | 108.24 KB | 1.00 | same |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 236.51 us | 222.39 us | 0.94 | same | 108.57 KB | 108.34 KB | 1.00 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.15 us | 13.10 us | 1.00 | same | 10.51 KB | 10.29 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.52 us | 12.24 us | 0.98 | same | 10.51 KB | 10.29 KB | 0.98 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 58.24 us | 56.76 us | 0.97 | same | 44.31 KB | 44.02 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 53.54 us | 53.50 us | 1.00 | same | 48.34 KB | 48.05 KB | 0.99 | same |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.62 us | 2.61 us | 1.00 | same | 2.19 KB | 2.02 KB | 0.93 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | 2.41 us | 2.43 us | 1.01 | same | 2.18 KB | 2.02 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.10 us | 1.01 us | 0.92 | faster | 1.83 KB | 1.66 KB | 0.91 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | 899.88 ns | 883.90 ns | 0.98 | same | 1.82 KB | 1.66 KB | 0.91 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.51 us | 2.49 us | 0.99 | same | 2.05 KB | 1.88 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | 2.38 us | 2.46 us | 1.03 | same | 2.04 KB | 1.88 KB | 0.92 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.00 us | 969.63 ns | 0.97 | same | 1.76 KB | 1.59 KB | 0.91 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | 871.07 ns | 864.05 ns | 0.99 | same | 1.75 KB | 1.59 KB | 0.91 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.28 us | 1.25 us | 0.98 | same | 1.84 KB | 1.67 KB | 0.91 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | 1.12 us | 1.11 us | 0.99 | same | 1.84 KB | 1.67 KB | 0.91 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 22.60 us | 21.69 us | 0.96 | same | 16.23 KB | 16.01 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | 20.06 us | 20.00 us | 1.00 | same | 16.15 KB | 15.93 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 19.30 us | 18.38 us | 0.95 | same | 14.89 KB | 14.67 KB | 0.99 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | 17.72 us | 17.64 us | 1.00 | same | 14.89 KB | 14.67 KB | 0.99 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.62 us / 11.77 KB | 15.41 us / 11.77 KB | 15.58 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 14.79 us / 11.55 KB | 15.53 us / 11.55 KB | 15.43 us / 11.55 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.29 us / 11.77 KB | 14.13 us / 11.77 KB | 14.66 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 13.80 us / 11.55 KB | 14.21 us / 11.55 KB | 13.95 us / 11.55 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 22.35 us / 13.04 KB | 22.17 us / 13.04 KB | 24.76 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 22.05 us / 12.82 KB | 22.05 us / 12.82 KB | 21.60 us / 12.82 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 20.66 us / 12.04 KB | 18.89 us / 11.90 KB | 24.09 us / 12.05 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 18.95 us / 11.70 KB | 18.99 us / 11.70 KB | 19.70 us / 11.76 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 251.42 us / 108.46 KB | 249.07 us / 108.46 KB | 273.14 us / 108.47 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 250.48 us / 108.23 KB | 246.70 us / 108.28 KB | 250.70 us / 108.24 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 222.12 us / 108.57 KB | 236.51 us / 108.57 KB | 468.91 us / 108.13 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 221.96 us / 108.34 KB | 283.84 us / 108.29 KB | 222.39 us / 108.34 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.15 us / 10.51 KB | 13.11 us / 10.51 KB | 13.59 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.05 us / 10.29 KB | 13.32 us / 10.29 KB | 13.10 us / 10.29 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.65 us / 10.51 KB | 12.34 us / 10.51 KB | 12.52 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 12.24 us / 10.29 KB | 12.32 us / 10.29 KB | 12.15 us / 10.29 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 57.08 us / 44.31 KB | 58.97 us / 44.31 KB | 58.24 us / 44.31 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 58.25 us / 44.02 KB | 56.54 us / 44.02 KB | 56.76 us / 44.02 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 53.54 us / 48.34 KB | 50.85 us / 44.30 KB | 101.96 us / 48.34 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 53.50 us / 48.05 KB | 65.31 us / 48.05 KB | 50.82 us / 44.02 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.53 us / 2.19 KB | 2.62 us / 2.19 KB | 2.71 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.66 us / 2.02 KB | 2.61 us / 2.02 KB | 2.50 us / 2.02 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | base | 2.41 us / 2.18 KB | 2.40 us / 2.18 KB | 4.00 us / 2.18 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | pr | 2.36 us / 2.02 KB | 2.49 us / 2.02 KB | 2.43 us / 2.02 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.05 us / 1.83 KB | 1.10 us / 1.83 KB | 1.12 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 1.02 us / 1.66 KB | 995.33 ns / 1.66 KB | 1.01 us / 1.66 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | base | 899.88 ns / 1.82 KB | 894.63 ns / 1.82 KB | 1.69 us / 1.82 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | pr | 883.90 ns / 1.66 KB | 880.41 ns / 1.66 KB | 916.23 ns / 1.66 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.47 us / 2.05 KB | 2.51 us / 2.05 KB | 2.55 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.49 us / 1.88 KB | 2.53 us / 1.88 KB | 2.46 us / 1.88 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | base | 2.35 us / 2.04 KB | 2.38 us / 2.04 KB | 3.97 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | pr | 2.37 us / 1.88 KB | 2.47 us / 1.88 KB | 2.46 us / 1.88 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.00 us / 1.76 KB | 994.04 ns / 1.76 KB | 1.10 us / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 969.63 ns / 1.59 KB | 999.65 ns / 1.59 KB | 968.36 ns / 1.59 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | base | 871.07 ns / 1.75 KB | 857.20 ns / 1.75 KB | 2.12 us / 1.75 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | pr | 864.05 ns / 1.59 KB | 878.70 ns / 1.59 KB | 854.42 ns / 1.59 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.27 us / 1.84 KB | 1.28 us / 1.84 KB | 1.35 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.23 us / 1.67 KB | 1.31 us / 1.67 KB | 1.25 us / 1.67 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | base | 1.12 us / 1.84 KB | 1.11 us / 1.84 KB | 1.91 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | pr | 1.11 us / 1.67 KB | 1.17 us / 1.67 KB | 1.09 us / 1.67 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 22.60 us / 16.23 KB | 21.92 us / 16.23 KB | 22.68 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 21.23 us / 16.01 KB | 21.85 us / 16.01 KB | 21.69 us / 16.01 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | base | 19.47 us / 16.15 KB | 20.31 us / 16.15 KB | 20.06 us / 16.15 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | pr | 19.82 us / 15.93 KB | 20.30 us / 15.93 KB | 20.00 us / 15.93 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 19.30 us / 14.89 KB | 19.02 us / 14.89 KB | 20.88 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 18.24 us / 14.67 KB | 18.96 us / 14.67 KB | 18.38 us / 14.67 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | base | 16.89 us / 14.89 KB | 17.72 us / 14.89 KB | 23.31 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | pr | 17.64 us / 14.67 KB | 18.08 us / 14.67 KB | 17.24 us / 14.67 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
