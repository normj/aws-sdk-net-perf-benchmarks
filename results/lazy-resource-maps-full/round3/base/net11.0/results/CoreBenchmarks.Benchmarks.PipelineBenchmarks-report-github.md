```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.03 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.65 μs |  0.060 μs |  0.036 μs | 0.3566 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.79 μs |  0.146 μs |  0.087 μs | 0.4159 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  20.77 μs |  0.413 μs |  0.246 μs | 0.4145 |   12.1 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.27 μs |  0.211 μs |  0.140 μs | 0.3966 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  24.12 μs |  1.538 μs |  1.017 μs | 0.4569 |  13.83 KB |
| InvokeSync_ServiceError                           |  53.05 μs |  0.436 μs |  0.259 μs | 1.4780 |   44.3 KB |
| InvokeAsync_ServiceError_Yielding                 | 248.15 μs | 19.622 μs | 12.979 μs | 3.1780 | 108.56 KB |
