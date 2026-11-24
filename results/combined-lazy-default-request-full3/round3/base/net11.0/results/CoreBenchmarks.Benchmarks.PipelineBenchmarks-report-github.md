```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.51 μs | 0.051 μs | 0.031 μs | 0.3494 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.53 μs | 0.071 μs | 0.047 μs | 0.4062 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.50 μs | 0.877 μs | 0.522 μs | 0.3802 |  11.92 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.25 μs | 0.110 μs | 0.065 μs | 0.3956 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.21 μs | 2.686 μs | 1.776 μs | 0.4257 |  13.67 KB |
| InvokeSync_ServiceError                           |  51.67 μs | 0.301 μs | 0.179 μs | 1.4344 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 222.11 μs | 1.288 μs | 0.766 μs | 3.1250 | 108.81 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.76 μs | 0.084 μs | 0.050 μs | 0.3571 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  19.54 μs | 0.066 μs | 0.040 μs | 0.3877 |  12.41 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.32 μs | 0.042 μs | 0.025 μs | 0.3730 |  11.16 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  20.15 μs | 0.224 μs | 0.133 μs | 0.3981 |  12.57 KB |
