```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.17 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  11.92 μs | 0.035 μs | 0.018 μs | 0.3376 |  10.05 KB |
| InvokeAsync_JsonPost                              |  14.26 μs | 0.060 μs | 0.040 μs | 0.3995 |  11.31 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.13 μs | 0.076 μs | 0.045 μs | 0.3839 |  11.55 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.64 μs | 0.148 μs | 0.088 μs | 0.3801 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  21.19 μs | 0.086 μs | 0.045 μs | 0.4229 |   13.4 KB |
| InvokeSync_ServiceError                           |  50.49 μs | 0.324 μs | 0.214 μs | 1.4068 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 222.12 μs | 1.417 μs | 0.843 μs | 3.5714 | 108.15 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.41 μs | 0.040 μs | 0.024 μs | 0.3467 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  19.50 μs | 0.146 μs | 0.097 μs | 0.3916 |  12.01 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  12.94 μs | 0.020 μs | 0.012 μs | 0.3652 |  10.71 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  20.79 μs | 0.181 μs | 0.108 μs | 0.4206 |  12.16 KB |
