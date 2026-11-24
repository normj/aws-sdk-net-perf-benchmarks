```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.57 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.94 μs | 0.069 μs | 0.046 μs | 0.3604 |  10.05 KB |
| InvokeAsync_JsonPost                              |  15.25 μs | 0.056 μs | 0.033 μs | 0.3687 |  11.31 KB |
| InvokeAsync_JsonPost_Yielding                     |  25.31 μs | 1.314 μs | 0.782 μs | 0.4078 |  11.57 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.82 μs | 0.070 μs | 0.042 μs | 0.4187 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  27.47 μs | 0.491 μs | 0.325 μs | 0.4529 |  13.53 KB |
| InvokeSync_ServiceError                           |  55.34 μs | 0.305 μs | 0.160 μs | 1.5459 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 291.12 μs | 3.212 μs | 2.125 μs | 3.4722 | 108.16 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.31 μs | 0.058 μs | 0.035 μs | 0.3743 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  26.17 μs | 1.311 μs | 0.867 μs | 0.4132 |  12.06 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.01 μs | 0.055 μs | 0.036 μs | 0.3882 |  10.71 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  27.10 μs | 0.898 μs | 0.534 μs | 0.4259 |  12.25 KB |
