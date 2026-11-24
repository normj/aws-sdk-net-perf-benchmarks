```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.83 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.23 μs | 0.102 μs | 0.067 μs | 0.3676 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.53 μs | 0.122 μs | 0.081 μs | 0.3695 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.43 μs | 2.306 μs | 1.525 μs | 0.4200 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.97 μs | 0.057 μs | 0.034 μs | 0.4191 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.35 μs | 2.164 μs | 1.431 μs | 0.5081 |  14.72 KB |
| InvokeSync_ServiceError                           |  58.35 μs | 0.436 μs | 0.288 μs | 1.4045 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 249.52 μs | 1.782 μs | 1.179 μs | 2.9762 | 108.71 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.79 μs | 0.060 μs | 0.035 μs | 0.3844 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  23.99 μs | 2.990 μs | 1.780 μs | 0.4496 |  13.53 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.28 μs | 0.132 μs | 0.079 μs | 0.3970 |  11.17 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  25.05 μs | 2.449 μs | 1.620 μs | 0.4623 |   13.7 KB |
