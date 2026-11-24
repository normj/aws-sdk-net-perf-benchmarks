```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.16 μs | 0.057 μs | 0.034 μs | 0.3439 |  10.05 KB |
| InvokeAsync_JsonPost                              |  14.23 μs | 0.041 μs | 0.022 μs | 0.3981 |  11.31 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.01 μs | 0.559 μs | 0.333 μs | 0.3747 |  11.45 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.89 μs | 0.065 μs | 0.043 μs | 0.3910 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.45 μs | 1.420 μs | 0.940 μs | 0.4161 |   13.2 KB |
| InvokeSync_ServiceError                           |  50.91 μs | 0.317 μs | 0.210 μs | 1.4205 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 226.59 μs | 2.637 μs | 1.569 μs | 3.5714 | 108.15 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.44 μs | 0.042 μs | 0.022 μs | 0.3469 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  19.10 μs | 0.117 μs | 0.077 μs | 0.3820 |  11.94 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.08 μs | 0.061 μs | 0.040 μs | 0.3655 |  10.71 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  21.92 μs | 2.107 μs | 1.393 μs | 0.3966 |  12.11 KB |
