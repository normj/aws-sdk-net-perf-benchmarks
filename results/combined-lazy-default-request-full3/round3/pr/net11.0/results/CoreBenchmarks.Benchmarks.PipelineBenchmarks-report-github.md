```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.11 μs | 0.057 μs | 0.038 μs | 0.3397 |  10.05 KB |
| InvokeAsync_JsonPost                              |  14.23 μs | 0.076 μs | 0.046 μs | 0.3981 |  11.31 KB |
| InvokeAsync_JsonPost_Yielding                     |  18.78 μs | 0.085 μs | 0.051 μs | 0.3788 |  11.47 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.89 μs | 0.043 μs | 0.023 μs | 0.3889 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.21 μs | 0.148 μs | 0.098 μs | 0.4257 |  13.27 KB |
| InvokeSync_ServiceError                           |  50.92 μs | 0.299 μs | 0.178 μs | 1.4159 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 220.35 μs | 0.630 μs | 0.375 μs | 3.5211 | 108.14 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.53 μs | 0.081 μs | 0.048 μs | 0.3497 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  20.02 μs | 2.004 μs | 1.192 μs | 0.3825 |  11.95 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  12.97 μs | 0.055 μs | 0.033 μs | 0.3619 |  10.71 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  19.99 μs | 0.188 μs | 0.125 μs | 0.3991 |  12.12 KB |
