```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.49 μs |  0.177 μs |  0.117 μs | 0.3453 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.89 μs |  3.648 μs |  2.413 μs | 0.3988 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.00 μs |  0.176 μs |  0.092 μs | 0.3802 |  11.93 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.19 μs |  0.071 μs |  0.047 μs | 0.3956 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  20.90 μs |  0.524 μs |  0.312 μs | 0.4172 |  13.72 KB |
| InvokeSync_ServiceError                           |  51.85 μs |  0.440 μs |  0.230 μs | 1.4632 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 265.70 μs | 71.124 μs | 47.044 μs | 3.6765 | 108.82 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.63 μs |  0.047 μs |  0.031 μs | 0.3528 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  19.19 μs |  0.174 μs |  0.091 μs | 0.3820 |  12.43 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.25 μs |  0.096 μs |  0.063 μs | 0.3711 |  11.16 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  21.44 μs |  2.492 μs |  1.649 μs | 0.3996 |  12.57 KB |
