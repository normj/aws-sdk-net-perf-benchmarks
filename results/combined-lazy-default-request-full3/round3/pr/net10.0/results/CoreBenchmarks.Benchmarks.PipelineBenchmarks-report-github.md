```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.45 μs | 0.143 μs | 0.094 μs | 0.3213 |  10.05 KB |
| InvokeAsync_JsonPost                              |  15.37 μs | 0.107 μs | 0.071 μs | 0.3676 |  11.32 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.03 μs | 1.297 μs | 0.772 μs | 0.4128 |  12.59 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.27 μs | 0.060 μs | 0.031 μs | 0.4256 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.10 μs | 2.035 μs | 1.346 μs | 0.4174 |  14.27 KB |
| InvokeSync_ServiceError                           |  57.82 μs | 0.542 μs | 0.359 μs | 1.3787 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 250.07 μs | 0.993 μs | 0.591 μs | 3.0242 | 108.03 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.80 μs | 0.104 μs | 0.069 μs | 0.3281 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  22.94 μs | 2.757 μs | 1.824 μs | 0.4589 |  13.08 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.48 μs | 0.087 μs | 0.051 μs | 0.3463 |  10.72 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  24.71 μs | 2.293 μs | 1.516 μs | 0.4223 |  13.25 KB |
