```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.57 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.22 μs | 0.148 μs | 0.098 μs | 0.3402 |  10.05 KB |
| InvokeAsync_JsonPost                              |  14.21 μs | 0.136 μs | 0.090 μs | 0.3917 |  11.31 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.28 μs | 1.192 μs | 0.709 μs | 0.3378 |  11.45 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.96 μs | 0.095 μs | 0.050 μs | 0.3875 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.05 μs | 1.223 μs | 0.809 μs | 0.4172 |  13.23 KB |
| InvokeSync_ServiceError                           |  51.59 μs | 0.312 μs | 0.186 μs | 1.4535 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 228.63 μs | 2.010 μs | 1.051 μs | 3.5714 | 108.14 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.68 μs | 0.067 μs | 0.040 μs | 0.3525 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  22.47 μs | 0.492 μs | 0.293 μs | 0.3546 |  11.99 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.99 μs | 0.119 μs | 0.079 μs | 0.3348 |  10.71 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  24.11 μs | 1.789 μs | 1.183 μs | 0.3687 |  12.16 KB |
