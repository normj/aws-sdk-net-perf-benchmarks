```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.13 μs |  0.151 μs | 0.100 μs | 0.3368 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.34 μs |  0.037 μs | 0.019 μs | 0.4032 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.05 μs |  1.368 μs | 0.905 μs | 0.3844 |  11.97 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.56 μs |  0.046 μs | 0.024 μs | 0.4337 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.41 μs |  0.314 μs | 0.207 μs | 0.4263 |  13.82 KB |
| InvokeSync_ServiceError                           |  51.67 μs |  0.112 μs | 0.066 μs | 1.4439 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 229.00 μs | 14.943 μs | 8.892 μs | 3.5714 | 108.81 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.26 μs |  0.067 μs | 0.044 μs | 0.3931 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  19.59 μs |  0.137 μs | 0.072 μs | 0.3901 |  12.45 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  12.85 μs |  0.029 μs | 0.015 μs | 0.3607 |  11.16 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  21.68 μs |  2.621 μs | 1.733 μs | 0.4043 |  12.63 KB |
