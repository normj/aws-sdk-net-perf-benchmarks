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
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.12 μs | 0.045 μs | 0.027 μs | 0.3698 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.36 μs | 0.207 μs | 0.137 μs | 0.3691 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  23.51 μs | 2.721 μs | 1.800 μs | 0.4269 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.85 μs | 0.045 μs | 0.030 μs | 0.4171 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  28.84 μs | 5.421 μs | 3.585 μs | 0.4713 |  14.72 KB |
| InvokeSync_ServiceError                           |  59.55 μs | 0.795 μs | 0.526 μs | 1.4259 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 253.13 μs | 3.548 μs | 2.111 μs | 2.9762 | 108.71 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.63 μs | 0.066 μs | 0.035 μs | 0.3866 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  24.33 μs | 2.563 μs | 1.695 μs | 0.4484 |  13.53 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.16 μs | 0.145 μs | 0.086 μs | 0.3963 |  11.17 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  25.67 μs | 2.851 μs | 1.886 μs | 0.4452 |   13.7 KB |
