```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.21 μs | 0.031 μs | 0.016 μs | 0.3423 |  10.51 KB |
| InvokeAsync_JsonPost                              |  13.96 μs | 0.035 μs | 0.021 μs | 0.3917 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.23 μs | 1.063 μs | 0.632 μs | 0.4012 |  12.14 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.72 μs | 0.024 μs | 0.014 μs | 0.4409 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.71 μs | 0.570 μs | 0.339 μs | 0.4377 |  13.76 KB |
| InvokeSync_ServiceError                           |  51.74 μs | 0.303 μs | 0.201 μs | 1.4439 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 227.28 μs | 1.637 μs | 1.082 μs | 3.6232 | 108.82 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.57 μs | 0.049 μs | 0.029 μs | 0.3511 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  19.68 μs | 0.087 μs | 0.045 μs | 0.3897 |  12.47 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.21 μs | 0.105 μs | 0.070 μs | 0.3704 |  11.16 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  20.51 μs | 0.281 μs | 0.167 μs | 0.4161 |  12.66 KB |
