### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `742f5920e609fc2d0b36685d11613876e7541513`
- Filter: `*Invoke*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.9 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** regression. At least one row is slower or allocates more.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | 25.67 us | 23.81 us | 0.93 | same | 13.70 KB | 13.25 KB | 0.97 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | 21.68 us | 24.11 us | 1.11 | same | 12.61 KB | 12.16 KB | 0.96 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | 14.65 us | 14.21 us | 0.97 | same | 11.17 KB | 10.72 KB | 0.96 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | 13.25 us | 13.99 us | 1.06 | same | 11.16 KB | 10.71 KB | 0.96 | less |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | 24.78 us | 23.62 us | 0.95 | same | 13.53 KB | 13.08 KB | 0.97 | less |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | 19.59 us | 22.47 us | 1.15 | same | 12.43 KB | 12.01 KB | 0.97 | less |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | 13.96 us | 13.54 us | 0.97 | same | 11.00 KB | 10.55 KB | 0.96 | less |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | 12.63 us | 12.68 us | 1.00 | same | 11.00 KB | 10.55 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.36 us | 15.06 us | 0.98 | same | 11.77 KB | 11.32 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.81 us | 14.26 us | 0.96 | same | 11.77 KB | 11.31 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 28.84 us | 26.34 us | 0.91 | same | 14.72 KB | 14.27 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 21.41 us | 22.05 us | 1.03 | same | 13.75 KB | 13.40 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 23.51 us | 22.55 us | 0.96 | same | 13.04 KB | 12.59 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.90 us | 19.28 us | 0.97 | same | 11.95 KB | 11.55 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 253.13 us | 267.91 us | 1.06 | same | 108.71 KB | 108.03 KB | 0.99 | same |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 233.68 us | 228.63 us | 0.98 | same | 108.82 KB | 108.15 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.40 us | 13.62 us | 1.02 | same | 10.51 KB | 10.05 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.49 us | 12.22 us | 0.98 | same | 10.51 KB | 10.05 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 15.24 us | 14.94 us | 0.98 | same | 12.19 KB | 11.73 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 14.19 us | 13.96 us | 0.98 | same | 12.19 KB | 11.73 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 59.55 us | 61.37 us | 1.03 | same | 44.53 KB | 43.90 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 51.85 us | 51.59 us | 1.00 | same | 44.53 KB | 43.90 KB | 0.99 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.57 us | 2.44 us | 0.95 | same | 2.19 KB | 1.79 KB | 0.82 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | 2.45 us | 2.51 us | 1.02 | same | 2.18 KB | 1.78 KB | 0.82 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.13 us | 968.90 ns | 0.86 | same | 1.83 KB | 1.43 KB | 0.78 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | 899.76 ns | 978.25 ns | 1.09 | same | 1.82 KB | 1.42 KB | 0.78 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.51 us | 2.51 us | 1.00 | same | 2.05 KB | 1.65 KB | 0.81 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | 2.42 us | 2.44 us | 1.01 | same | 2.04 KB | 1.64 KB | 0.80 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.03 us | 943.60 ns | 0.92 | same | 1.76 KB | 1.36 KB | 0.77 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | 872.75 ns | 935.91 ns | 1.07 | same | 1.75 KB | 1.35 KB | 0.77 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.31 us | 1.25 us | 0.95 | same | 1.84 KB | 1.44 KB | 0.78 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | 1.16 us | 1.18 us | 1.01 | same | 1.84 KB | 1.44 KB | 0.78 | less |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | 17.20 us | 16.86 us | 0.98 | same | 12.06 KB | 11.61 KB | 0.96 | less |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | 15.90 us | 16.65 us | 1.05 | same | 11.98 KB | 11.53 KB | 0.96 | less |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | 14.40 us | 14.29 us | 0.99 | same | 10.73 KB | 10.27 KB | 0.96 | less |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | 13.45 us | 14.08 us | 1.05 | same | 10.73 KB | 10.27 KB | 0.96 | less |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | 18.10 us | 17.98 us | 0.99 | same | 12.35 KB | 11.90 KB | 0.96 | less |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | 17.20 us | 17.72 us | 1.03 | same | 12.27 KB | 11.82 KB | 0.96 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 21.66 us | 21.80 us | 1.01 | same | 16.23 KB | 15.77 KB | 0.97 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | 20.56 us | 21.61 us | 1.05 | **slower** | 16.15 KB | 15.70 KB | 0.97 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 18.67 us | 18.76 us | 1.00 | same | 14.89 KB | 14.44 KB | 0.97 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | 17.82 us | 18.70 us | 1.05 | same | 14.89 KB | 14.44 KB | 0.97 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | base | 25.67 us / 13.70 KB | 25.21 us / 13.70 KB | 28.45 us / 13.70 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.55 us / 13.25 KB | 23.81 us / 13.25 KB | 38.36 us / 13.25 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | base | 21.44 us / 12.57 KB | 21.68 us / 12.63 KB | 21.79 us / 12.61 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | pr | 20.79 us / 12.16 KB | 24.11 us / 12.16 KB | 27.10 us / 12.25 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | base | 14.16 us / 11.17 KB | 14.65 us / 11.17 KB | 15.08 us / 11.17 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | pr | 14.21 us / 10.72 KB | 13.75 us / 10.72 KB | 15.44 us / 10.72 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | base | 13.25 us / 11.16 KB | 12.85 us / 11.16 KB | 13.43 us / 11.16 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | pr | 12.94 us / 10.71 KB | 13.99 us / 10.71 KB | 14.01 us / 10.71 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | base | 24.33 us / 13.53 KB | 24.78 us / 13.53 KB | 34.57 us / 13.53 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.30 us / 13.08 KB | 23.62 us / 13.08 KB | 36.68 us / 13.08 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | base | 19.19 us / 12.43 KB | 19.59 us / 12.45 KB | 21.38 us / 12.43 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | pr | 19.50 us / 12.01 KB | 22.47 us / 11.99 KB | 26.17 us / 12.06 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | base | 13.63 us / 11.00 KB | 13.96 us / 11.00 KB | 14.57 us / 11.00 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | pr | 13.54 us / 10.55 KB | 13.43 us / 10.55 KB | 14.71 us / 10.55 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | base | 12.63 us / 11.00 KB | 12.26 us / 11.00 KB | 12.94 us / 11.00 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | pr | 12.41 us / 10.55 KB | 12.68 us / 10.55 KB | 13.31 us / 10.55 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.36 us / 11.77 KB | 15.27 us / 11.77 KB | 16.38 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.06 us / 11.32 KB | 15.01 us / 11.32 KB | 15.67 us / 11.32 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 15.89 us / 11.77 KB | 14.34 us / 11.77 KB | 14.81 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 14.26 us / 11.31 KB | 14.21 us / 11.31 KB | 15.25 us / 11.31 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 28.84 us / 14.72 KB | 25.55 us / 14.72 KB | 38.27 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 26.12 us / 14.27 KB | 26.34 us / 14.27 KB | 38.76 us / 14.27 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 20.90 us / 13.72 KB | 21.41 us / 13.82 KB | 22.15 us / 13.75 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 21.19 us / 13.40 KB | 22.05 us / 13.23 KB | 27.47 us / 13.53 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 23.51 us / 13.04 KB | 23.38 us / 13.04 KB | 31.43 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 22.55 us / 12.58 KB | 21.40 us / 12.59 KB | 34.98 us / 12.59 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 19.00 us / 11.93 KB | 20.05 us / 11.97 KB | 19.90 us / 11.95 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 19.13 us / 11.55 KB | 19.28 us / 11.45 KB | 25.31 us / 11.57 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 253.13 us / 108.71 KB | 252.65 us / 108.71 KB | 312.95 us / 108.75 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 252.59 us / 108.03 KB | 267.91 us / 108.03 KB | 316.41 us / 108.07 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 265.70 us / 108.82 KB | 229.00 us / 108.81 KB | 233.68 us / 108.82 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 222.12 us / 108.15 KB | 228.63 us / 108.14 KB | 291.12 us / 108.16 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.12 us / 10.51 KB | 13.40 us / 10.51 KB | 14.11 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 13.62 us / 10.05 KB | 12.85 us / 10.05 KB | 13.75 us / 10.05 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.49 us / 10.51 KB | 12.13 us / 10.51 KB | 12.62 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 11.92 us / 10.05 KB | 12.22 us / 10.05 KB | 12.94 us / 10.05 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 14.85 us / 12.19 KB | 15.24 us / 12.19 KB | 16.18 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.94 us / 11.73 KB | 14.61 us / 11.73 KB | 16.28 us / 11.73 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 14.19 us / 12.19 KB | 13.56 us / 12.19 KB | 14.26 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 13.64 us / 11.73 KB | 13.96 us / 11.73 KB | 14.82 us / 11.73 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 59.55 us / 44.53 KB | 58.43 us / 44.53 KB | 62.57 us / 44.53 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 61.37 us / 43.90 KB | 57.49 us / 43.90 KB | 62.36 us / 43.90 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 51.85 us / 44.53 KB | 51.67 us / 44.53 KB | 53.82 us / 44.53 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 50.49 us / 43.90 KB | 51.59 us / 43.90 KB | 55.34 us / 43.90 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.50 us / 2.19 KB | 2.57 us / 2.19 KB | 2.64 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.41 us / 1.79 KB | 2.44 us / 1.79 KB | 2.69 us / 1.79 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | base | 2.42 us / 2.18 KB | 2.45 us / 2.18 KB | 2.52 us / 2.18 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | pr | 2.28 us / 1.78 KB | 2.51 us / 1.78 KB | 2.53 us / 1.78 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.09 us / 1.83 KB | 1.13 us / 1.83 KB | 1.15 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 945.72 ns / 1.43 KB | 968.90 ns / 1.43 KB | 1.12 us / 1.43 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | base | 885.43 ns / 1.82 KB | 899.76 ns / 1.82 KB | 1.01 us / 1.82 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | pr | 850.98 ns / 1.42 KB | 978.25 ns / 1.42 KB | 1.03 us / 1.42 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.50 us / 2.05 KB | 2.51 us / 2.05 KB | 2.60 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.39 us / 1.65 KB | 2.51 us / 1.65 KB | 2.62 us / 1.65 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | base | 2.42 us / 2.04 KB | 2.42 us / 2.04 KB | 2.43 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | pr | 2.27 us / 1.64 KB | 2.44 us / 1.64 KB | 2.47 us / 1.64 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.03 us / 1.76 KB | 1.00 us / 1.76 KB | 1.09 us / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 918.59 ns / 1.36 KB | 943.60 ns / 1.36 KB | 1.10 us / 1.36 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | base | 872.75 ns / 1.75 KB | 866.84 ns / 1.75 KB | 959.78 ns / 1.75 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | pr | 925.40 ns / 1.35 KB | 935.91 ns / 1.35 KB | 941.06 ns / 1.35 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.28 us / 1.84 KB | 1.31 us / 1.84 KB | 1.36 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.17 us / 1.44 KB | 1.25 us / 1.44 KB | 1.34 us / 1.44 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | base | 1.10 us / 1.84 KB | 1.16 us / 1.84 KB | 1.19 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | pr | 1.05 us / 1.44 KB | 1.18 us / 1.44 KB | 1.18 us / 1.44 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | base | 16.92 us / 12.06 KB | 17.20 us / 12.06 KB | 17.33 us / 12.06 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | pr | 16.86 us / 11.61 KB | 16.33 us / 11.61 KB | 18.00 us / 11.61 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | base | 15.55 us / 11.98 KB | 15.90 us / 11.98 KB | 16.46 us / 11.98 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | pr | 15.13 us / 11.53 KB | 16.65 us / 11.53 KB | 16.75 us / 11.53 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | base | 14.40 us / 10.73 KB | 14.68 us / 10.73 KB | 14.35 us / 10.73 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | pr | 14.29 us / 10.27 KB | 13.94 us / 10.27 KB | 15.49 us / 10.27 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | base | 13.43 us / 10.73 KB | 13.45 us / 10.73 KB | 14.21 us / 10.73 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | pr | 13.04 us / 10.27 KB | 14.08 us / 10.27 KB | 14.09 us / 10.27 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | base | 17.86 us / 12.35 KB | 18.10 us / 12.35 KB | 18.53 us / 12.35 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | pr | 17.98 us / 11.90 KB | 17.65 us / 11.90 KB | 19.37 us / 11.90 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | base | 16.58 us / 12.27 KB | 17.20 us / 12.27 KB | 17.55 us / 12.27 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | pr | 17.63 us / 11.82 KB | 17.72 us / 11.82 KB | 17.85 us / 11.82 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 21.66 us / 16.23 KB | 21.76 us / 16.23 KB | 21.58 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 21.80 us / 15.77 KB | 21.26 us / 15.77 KB | 23.76 us / 15.77 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | base | 20.40 us / 16.15 KB | 20.56 us / 16.15 KB | 21.15 us / 16.15 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | pr | 21.61 us / 15.70 KB | 21.58 us / 15.70 KB | 21.84 us / 15.70 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 18.67 us / 14.89 KB | 18.64 us / 14.89 KB | 19.19 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 18.76 us / 14.44 KB | 18.46 us / 14.44 KB | 20.41 us / 14.44 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | base | 17.67 us / 14.89 KB | 17.82 us / 14.89 KB | 18.55 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | pr | 17.11 us / 14.44 KB | 18.70 us / 14.44 KB | 19.01 us / 14.44 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
