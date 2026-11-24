```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.56 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  14.11 μs |  0.194 μs | 0.116 μs | 0.3342 |  10.51 KB |
| InvokeAsync_JsonPost                              |  16.38 μs |  0.220 μs | 0.131 μs | 0.3914 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  31.43 μs |  4.550 μs | 3.010 μs | 0.3648 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  16.18 μs |  0.120 μs | 0.079 μs | 0.3866 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  38.27 μs |  1.261 μs | 0.834 μs | 0.4433 |  14.72 KB |
| InvokeSync_ServiceError                           |  62.57 μs |  0.454 μs | 0.270 μs | 1.5000 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 312.95 μs | 10.515 μs | 6.955 μs | 3.6765 | 108.75 KB |
| EndpointRules_InvokeSync_JsonPost                 |  14.57 μs |  0.104 μs | 0.069 μs | 0.3511 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  34.57 μs |  2.951 μs | 1.952 μs | 0.3998 |  13.53 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  15.08 μs |  0.311 μs | 0.206 μs | 0.3709 |  11.17 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  28.45 μs |  1.948 μs | 1.289 μs | 0.4433 |   13.7 KB |
