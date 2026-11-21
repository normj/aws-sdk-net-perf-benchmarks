```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.67 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error      | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|-----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.96 μs |   1.670 μs |  0.596 μs | 0.3327 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.61 μs |   0.283 μs |  0.101 μs | 0.3780 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  25.95 μs |   6.613 μs |  2.358 μs | 0.4105 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.51 μs |   0.996 μs |  0.355 μs | 0.4231 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  30.94 μs |  12.860 μs |  4.586 μs | 0.4233 |  14.72 KB |
| InvokeSync_ServiceError                           |  58.24 μs |   2.705 μs |  0.965 μs | 1.6026 |  44.32 KB |
| InvokeAsync_ServiceError_Yielding                 | 334.15 μs | 112.110 μs | 39.979 μs | 3.8265 |  108.5 KB |
