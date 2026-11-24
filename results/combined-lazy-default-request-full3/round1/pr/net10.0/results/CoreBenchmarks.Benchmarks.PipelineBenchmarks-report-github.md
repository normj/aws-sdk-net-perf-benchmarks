```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.02 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.82 μs | 0.050 μs | 0.026 μs | 0.3622 |  10.05 KB |
| InvokeAsync_JsonPost                              |  15.17 μs | 0.122 μs | 0.081 μs | 0.3616 |  11.32 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.90 μs | 1.004 μs | 0.525 μs | 0.4053 |  12.58 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.93 μs | 0.075 μs | 0.050 μs | 0.4167 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.32 μs | 2.083 μs | 1.378 μs | 0.4288 |  14.27 KB |
| InvokeSync_ServiceError                           |  57.59 μs | 0.617 μs | 0.408 μs | 1.3736 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 248.01 μs | 1.934 μs | 1.012 μs | 3.9063 | 108.06 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.24 μs | 0.046 μs | 0.024 μs | 0.3711 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  23.72 μs | 2.404 μs | 1.590 μs | 0.3987 |  13.08 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.12 μs | 0.073 μs | 0.049 μs | 0.3397 |  10.72 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  24.63 μs | 2.427 μs | 1.605 μs | 0.4764 |  13.25 KB |
