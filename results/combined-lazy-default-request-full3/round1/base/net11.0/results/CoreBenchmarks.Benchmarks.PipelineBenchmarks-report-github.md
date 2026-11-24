```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.35 μs | 0.016 μs | 0.009 μs | 0.3472 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.59 μs | 0.127 μs | 0.076 μs | 0.4070 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.96 μs | 1.111 μs | 0.735 μs | 0.4090 |  11.92 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.91 μs | 0.035 μs | 0.021 μs | 0.3882 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.64 μs | 2.313 μs | 1.530 μs | 0.4287 |  13.76 KB |
| InvokeSync_ServiceError                           |  51.38 μs | 0.127 μs | 0.076 μs | 1.4391 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 224.13 μs | 2.594 μs | 1.357 μs | 3.5714 | 108.81 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.74 μs | 0.044 μs | 0.023 μs | 0.3557 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  20.48 μs | 1.086 μs | 0.719 μs | 0.4064 |  12.44 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.51 μs | 0.052 μs | 0.035 μs | 0.3831 |  11.16 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  20.44 μs | 0.133 μs | 0.079 μs | 0.4058 |  12.59 KB |
