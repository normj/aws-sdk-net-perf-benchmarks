### BenchmarkDotNet A/B results

- Base: `63acef108559c9e7cb454c4a233f9d5638fb5fd2`
- PR: `742f5920e609fc2d0b36685d11613876e7541513`
- Filter: `*Invoke*`
- Benchmark source: `aws-sdk-net-perf-benchmarks@c06ad5eb70a10efbcbd027070e4388f09137b8eb`
- 3 interleaved rounds (base, PR, base, PR, ...), MemoryDiagnoser. Values are the median of the per-round means.
- Time verdict is `faster` or `slower` only when the median changes by at least 5% and every PR round beats (or loses to) every base round. Alloc verdict uses the same rule with a 1% threshold.
- Busiest start of a measurement: 1.1 other runnable tasks (ab.sh waits for at most AB_MAX_LOAD).

**Overall:** win: 4/42 rows faster, 40/42 rows allocate less.

| Benchmark | Runtime | Base mean | PR mean | Time ratio | Time | Base alloc | PR alloc | Alloc ratio | Alloc |
|---|---|---:|---:|---:|---|---:|---:|---:|---|
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | 25.05 us | 24.63 us | 0.98 | same | 13.70 KB | 13.25 KB | 0.97 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | 20.44 us | 20.59 us | 1.01 | same | 12.59 KB | 12.12 KB | 0.96 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | 14.28 us | 14.12 us | 0.99 | same | 11.17 KB | 10.72 KB | 0.96 | less |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | 13.32 us | 12.97 us | 0.97 | same | 11.16 KB | 10.71 KB | 0.96 | less |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | 24.00 us | 23.02 us | 0.96 | same | 13.53 KB | 13.08 KB | 0.97 | less |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | 19.68 us | 19.54 us | 0.99 | same | 12.44 KB | 11.95 KB | 0.96 | less |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | 13.79 us | 13.42 us | 0.97 | same | 11.00 KB | 10.55 KB | 0.96 | less |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | 12.74 us | 12.44 us | 0.98 | same | 11.00 KB | 10.55 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | 15.53 us | 15.37 us | 0.99 | same | 11.77 KB | 11.32 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | 14.53 us | 14.23 us | 0.98 | same | 11.77 KB | 11.31 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | 26.35 us | 25.32 us | 0.96 | same | 14.72 KB | 14.27 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | 22.21 us | 21.45 us | 0.97 | same | 13.76 KB | 13.27 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | 22.43 us | 21.83 us | 0.97 | same | 13.04 KB | 12.59 KB | 0.97 | less |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | 19.96 us | 19.01 us | 0.95 | same | 11.92 KB | 11.47 KB | 0.96 | less |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | 251.87 us | 250.07 us | 0.99 | same | 108.71 KB | 108.03 KB | 0.99 | same |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | 224.13 us | 226.59 us | 1.01 | same | 108.81 KB | 108.14 KB | 0.99 | same |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | 13.23 us | 12.87 us | 0.97 | same | 10.51 KB | 10.05 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | 12.35 us | 12.11 us | 0.98 | same | 10.51 KB | 10.05 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | 14.97 us | 14.93 us | 1.00 | same | 12.19 KB | 11.73 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | 13.91 us | 13.89 us | 1.00 | same | 12.19 KB | 11.73 KB | 0.96 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | 59.02 us | 57.59 us | 0.98 | same | 44.53 KB | 43.90 KB | 0.99 | less |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | 51.67 us | 50.92 us | 0.99 | same | 44.53 KB | 43.90 KB | 0.99 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | 2.51 us | 2.48 us | 0.99 | same | 2.19 KB | 1.79 KB | 0.82 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | 2.46 us | 2.35 us | 0.96 | same | 2.18 KB | 1.78 KB | 0.82 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | 1.04 us | 963.50 ns | 0.92 | faster | 1.83 KB | 1.43 KB | 0.78 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | 905.35 ns | 836.81 ns | 0.92 | same | 1.82 KB | 1.42 KB | 0.78 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | 2.48 us | 2.43 us | 0.98 | same | 2.05 KB | 1.65 KB | 0.81 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | 2.37 us | 2.29 us | 0.97 | same | 2.04 KB | 1.64 KB | 0.80 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | 1.00 us | 930.22 ns | 0.93 | faster | 1.76 KB | 1.36 KB | 0.77 | less |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | 866.88 ns | 797.62 ns | 0.92 | faster | 1.75 KB | 1.35 KB | 0.77 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | 1.32 us | 1.18 us | 0.89 | faster | 1.84 KB | 1.44 KB | 0.78 | less |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | 1.11 us | 1.05 us | 0.95 | same | 1.84 KB | 1.44 KB | 0.78 | less |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | 16.92 us | 16.76 us | 0.99 | same | 12.06 KB | 11.61 KB | 0.96 | less |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | 15.89 us | 15.44 us | 0.97 | same | 11.98 KB | 11.53 KB | 0.96 | less |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | 14.36 us | 14.26 us | 0.99 | same | 10.73 KB | 10.27 KB | 0.96 | less |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | 13.67 us | 13.11 us | 0.96 | same | 10.73 KB | 10.27 KB | 0.96 | less |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | 18.09 us | 17.62 us | 0.97 | same | 12.35 KB | 11.90 KB | 0.96 | less |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | 16.84 us | 16.47 us | 0.98 | same | 12.27 KB | 11.82 KB | 0.96 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | 21.81 us | 21.35 us | 0.98 | same | 16.23 KB | 15.77 KB | 0.97 | less |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | 20.51 us | 20.00 us | 0.98 | same | 16.15 KB | 15.70 KB | 0.97 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | 18.83 us | 18.65 us | 0.99 | same | 14.89 KB | 14.44 KB | 0.97 | less |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | 17.86 us | 17.06 us | 0.96 | same | 14.89 KB | 14.44 KB | 0.97 | less |

<details><summary>Per-round means</summary>

| Benchmark | Runtime | Side | Round 1 | Round 2 | Round 3 |
|---|---|---|---:|---:|---:|
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | base | 31.30 us / 13.70 KB | 25.05 us / 13.70 KB | 24.57 us / 13.70 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net10.0 | pr | 24.63 us / 13.25 KB | 23.85 us / 13.25 KB | 24.71 us / 13.25 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | base | 20.44 us / 12.59 KB | 20.51 us / 12.66 KB | 20.15 us / 12.57 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeAsync_JsonPost_Yielding | net11.0 | pr | 21.92 us / 12.11 KB | 20.59 us / 12.29 KB | 19.99 us / 12.12 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | base | 14.72 us / 11.17 KB | 14.28 us / 11.17 KB | 14.02 us / 11.17 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net10.0 | pr | 14.12 us / 10.72 KB | 13.87 us / 10.72 KB | 14.48 us / 10.72 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | base | 13.51 us / 11.16 KB | 13.21 us / 11.16 KB | 13.32 us / 11.16 KB |
| PipelineBenchmarks.EndpointDiscovery_InvokeSync_JsonPost | net11.0 | pr | 13.08 us / 10.71 KB | 12.78 us / 10.71 KB | 12.97 us / 10.71 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | base | 25.02 us / 13.53 KB | 23.99 us / 13.53 KB | 24.00 us / 13.53 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net10.0 | pr | 23.72 us / 13.08 KB | 23.02 us / 13.08 KB | 22.94 us / 13.08 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | base | 20.48 us / 12.44 KB | 19.68 us / 12.47 KB | 19.54 us / 12.41 KB |
| PipelineBenchmarks.EndpointRules_InvokeAsync_JsonPost_Yielding | net11.0 | pr | 19.10 us / 11.94 KB | 19.54 us / 12.05 KB | 20.02 us / 11.95 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | base | 13.79 us / 11.00 KB | 13.79 us / 11.00 KB | 13.47 us / 11.00 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net10.0 | pr | 13.24 us / 10.55 KB | 13.42 us / 10.55 KB | 13.80 us / 10.55 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | base | 12.74 us / 11.00 KB | 12.57 us / 11.00 KB | 12.76 us / 11.00 KB |
| PipelineBenchmarks.EndpointRules_InvokeSync_JsonPost | net11.0 | pr | 12.44 us / 10.55 KB | 12.09 us / 10.55 KB | 12.53 us / 10.55 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | base | 15.89 us / 11.77 KB | 15.53 us / 11.77 KB | 15.35 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net10.0 | pr | 15.17 us / 11.32 KB | 15.60 us / 11.32 KB | 15.37 us / 11.32 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | base | 14.59 us / 11.77 KB | 13.96 us / 11.77 KB | 14.53 us / 11.77 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost | net11.0 | pr | 14.23 us / 11.31 KB | 13.87 us / 11.31 KB | 14.23 us / 11.31 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | base | 27.43 us / 14.72 KB | 26.35 us / 14.72 KB | 26.18 us / 14.72 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net10.0 | pr | 25.32 us / 14.27 KB | 25.86 us / 14.27 KB | 25.10 us / 14.27 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | base | 22.64 us / 13.76 KB | 21.71 us / 13.76 KB | 22.21 us / 13.67 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | net11.0 | pr | 21.45 us / 13.20 KB | 22.05 us / 13.44 KB | 21.21 us / 13.27 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | base | 23.00 us / 13.04 KB | 22.43 us / 13.04 KB | 22.21 us / 13.04 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net10.0 | pr | 20.90 us / 12.58 KB | 21.83 us / 12.59 KB | 22.03 us / 12.59 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | base | 19.96 us / 11.92 KB | 20.23 us / 12.14 KB | 19.50 us / 11.92 KB |
| PipelineBenchmarks.InvokeAsync_JsonPost_Yielding | net11.0 | pr | 19.01 us / 11.45 KB | 19.06 us / 11.55 KB | 18.78 us / 11.47 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | base | 251.87 us / 108.71 KB | 249.52 us / 108.71 KB | 256.60 us / 108.75 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net10.0 | pr | 248.01 us / 108.06 KB | 251.08 us / 108.03 KB | 250.07 us / 108.03 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | base | 224.13 us / 108.81 KB | 227.28 us / 108.82 KB | 222.11 us / 108.81 KB |
| PipelineBenchmarks.InvokeAsync_ServiceError_Yielding | net11.0 | pr | 226.59 us / 108.15 KB | 241.11 us / 108.14 KB | 220.35 us / 108.14 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | base | 13.45 us / 10.51 KB | 13.23 us / 10.51 KB | 12.95 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net10.0 | pr | 12.82 us / 10.05 KB | 12.87 us / 10.05 KB | 13.45 us / 10.05 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | base | 12.35 us / 10.51 KB | 12.21 us / 10.51 KB | 12.51 us / 10.51 KB |
| PipelineBenchmarks.InvokeSync_JsonPost | net11.0 | pr | 12.16 us / 10.05 KB | 11.86 us / 10.05 KB | 12.11 us / 10.05 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | base | 15.17 us / 12.19 KB | 14.97 us / 12.19 KB | 14.90 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net10.0 | pr | 14.93 us / 11.73 KB | 14.64 us / 11.73 KB | 15.27 us / 11.73 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | base | 13.91 us / 12.19 KB | 13.72 us / 12.19 KB | 14.25 us / 12.19 KB |
| PipelineBenchmarks.InvokeSync_JsonPost_ManyResponseHeaders | net11.0 | pr | 13.89 us / 11.73 KB | 13.47 us / 11.73 KB | 13.89 us / 11.73 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | base | 60.01 us / 44.53 KB | 58.35 us / 44.53 KB | 59.02 us / 44.53 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net10.0 | pr | 57.59 us / 43.90 KB | 57.43 us / 43.91 KB | 57.82 us / 43.90 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | base | 51.38 us / 44.53 KB | 51.74 us / 44.53 KB | 51.67 us / 44.53 KB |
| PipelineBenchmarks.InvokeSync_ServiceError | net11.0 | pr | 50.91 us / 43.90 KB | 51.11 us / 43.90 KB | 50.92 us / 43.90 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | base | 2.57 us / 2.19 KB | 2.51 us / 2.19 KB | 2.47 us / 2.19 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net10.0 | pr | 2.47 us / 1.79 KB | 2.48 us / 1.79 KB | 2.51 us / 1.79 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | base | 2.47 us / 2.18 KB | 2.40 us / 2.18 KB | 2.46 us / 2.18 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_DefaultChain | net11.0 | pr | 2.37 us / 1.78 KB | 2.35 us / 1.78 KB | 2.34 us / 1.78 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | base | 1.07 us / 1.83 KB | 1.03 us / 1.83 KB | 1.04 us / 1.83 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net10.0 | pr | 946.36 ns / 1.43 KB | 967.48 ns / 1.43 KB | 963.50 ns / 1.43 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | base | 892.55 ns / 1.82 KB | 939.78 ns / 1.82 KB | 905.35 ns / 1.82 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvokeAsync_ExplicitCredentials | net11.0 | pr | 907.04 ns / 1.42 KB | 836.81 ns / 1.42 KB | 818.64 ns / 1.42 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | base | 2.56 us / 2.05 KB | 2.48 us / 2.05 KB | 2.45 us / 2.05 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net10.0 | pr | 2.43 us / 1.65 KB | 2.45 us / 1.65 KB | 2.39 us / 1.65 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | base | 2.37 us / 2.04 KB | 2.33 us / 2.04 KB | 2.42 us / 2.04 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_DefaultChain | net11.0 | pr | 2.26 us / 1.64 KB | 2.29 us / 1.64 KB | 2.29 us / 1.64 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | base | 1.02 us / 1.76 KB | 1.00 us / 1.76 KB | 993.98 ns / 1.76 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net10.0 | pr | 930.22 ns / 1.36 KB | 944.43 ns / 1.36 KB | 922.97 ns / 1.36 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | base | 866.88 ns / 1.75 KB | 865.86 ns / 1.75 KB | 867.26 ns / 1.75 KB |
| RequestSetupBenchmarks.AuthResolver_PreInvoke_ExplicitCredentials | net11.0 | pr | 799.85 ns / 1.35 KB | 791.52 ns / 1.35 KB | 797.62 ns / 1.35 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | base | 1.38 us / 1.84 KB | 1.28 us / 1.84 KB | 1.32 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net10.0 | pr | 1.17 us / 1.44 KB | 1.21 us / 1.44 KB | 1.18 us / 1.44 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | base | 1.10 us / 1.84 KB | 1.12 us / 1.84 KB | 1.11 us / 1.84 KB |
| RequestSetupBenchmarks.Marshaller_PreInvoke | net11.0 | pr | 1.05 us / 1.44 KB | 1.04 us / 1.44 KB | 1.06 us / 1.44 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | base | 26.69 us / 12.06 KB | 16.92 us / 12.06 KB | 16.79 us / 12.06 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net10.0 | pr | 16.81 us / 11.61 KB | 16.76 us / 11.61 KB | 16.50 us / 11.61 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | base | 15.89 us / 11.98 KB | 15.77 us / 11.98 KB | 15.94 us / 11.98 KB |
| RequestSetupBenchmarks.NewRequest_InvokeAsync | net11.0 | pr | 15.44 us / 11.53 KB | 15.59 us / 11.53 KB | 15.42 us / 11.53 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | base | 22.70 us / 10.73 KB | 14.36 us / 10.73 KB | 14.24 us / 10.73 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net10.0 | pr | 14.16 us / 10.27 KB | 14.26 us / 10.27 KB | 14.28 us / 10.27 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | base | 13.72 us / 10.73 KB | 13.46 us / 10.73 KB | 13.67 us / 10.73 KB |
| RequestSetupBenchmarks.NewRequest_InvokeSync | net11.0 | pr | 13.11 us / 10.27 KB | 12.93 us / 10.27 KB | 13.14 us / 10.27 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | base | 25.50 us / 12.35 KB | 18.09 us / 12.35 KB | 17.87 us / 12.35 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net10.0 | pr | 17.62 us / 11.90 KB | 17.76 us / 11.90 KB | 17.48 us / 11.90 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | base | 16.84 us / 12.27 KB | 17.01 us / 12.27 KB | 16.83 us / 12.27 KB |
| RequestSetupBenchmarks.RefreshingCredentials_InvokeAsync | net11.0 | pr | 16.42 us / 11.82 KB | 16.47 us / 11.82 KB | 16.55 us / 11.82 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | base | 22.45 us / 16.23 KB | 21.81 us / 16.23 KB | 21.54 us / 16.23 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net10.0 | pr | 21.48 us / 15.77 KB | 21.35 us / 15.77 KB | 21.18 us / 15.77 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | base | 20.48 us / 16.15 KB | 20.67 us / 16.15 KB | 20.51 us / 16.15 KB |
| RequestSetupBenchmarks.Telemetry_InvokeAsync | net11.0 | pr | 20.09 us / 15.70 KB | 19.95 us / 15.70 KB | 20.00 us / 15.70 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | base | 19.00 us / 14.89 KB | 18.83 us / 14.89 KB | 18.47 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net10.0 | pr | 18.75 us / 14.44 KB | 18.65 us / 14.44 KB | 18.62 us / 14.44 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | base | 17.71 us / 14.89 KB | 17.90 us / 14.89 KB | 17.86 us / 14.89 KB |
| RequestSetupBenchmarks.Telemetry_InvokeSync | net11.0 | pr | 17.36 us / 14.44 KB | 17.01 us / 14.44 KB | 17.06 us / 14.44 KB |

</details>

<details><summary>Environment</summary>

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.28 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

```
BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3
```

</details>
