```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.15 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.40 μs | 0.120 μs | 0.063 μs | 0.3739 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.27 μs | 0.100 μs | 0.066 μs | 0.3684 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  23.38 μs | 2.378 μs | 1.415 μs | 0.4420 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.24 μs | 0.115 μs | 0.060 μs | 0.4285 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.55 μs | 2.538 μs | 1.679 μs | 0.4348 |  14.72 KB |
| InvokeSync_ServiceError                           |  58.43 μs | 0.777 μs | 0.514 μs | 1.3889 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 252.65 μs | 7.464 μs | 4.442 μs | 2.9762 | 108.71 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.96 μs | 0.051 μs | 0.034 μs | 0.3903 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  24.78 μs | 1.525 μs | 1.009 μs | 0.4713 |  13.53 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.65 μs | 0.124 μs | 0.082 μs | 0.3479 |  11.17 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  25.21 μs | 2.586 μs | 1.710 μs | 0.4065 |   13.7 KB |
