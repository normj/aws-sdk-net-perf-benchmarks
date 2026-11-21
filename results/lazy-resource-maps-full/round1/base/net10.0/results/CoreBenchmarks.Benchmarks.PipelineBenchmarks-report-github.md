```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.46 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.88 μs |  0.342 μs |  0.226 μs | 0.3316 |  10.51 KB |
| InvokeAsync_JsonPost                              |  16.73 μs |  0.959 μs |  0.634 μs | 0.3910 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  27.70 μs |  3.306 μs |  2.187 μs | 0.3968 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  16.62 μs |  0.934 μs |  0.617 μs | 0.3894 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  34.44 μs |  3.494 μs |  2.311 μs | 0.5165 |  14.72 KB |
| InvokeSync_ServiceError                           |  72.82 μs | 11.514 μs |  7.616 μs | 1.5432 |  48.34 KB |
| InvokeAsync_ServiceError_Yielding                 | 311.84 μs | 18.293 μs | 12.099 μs | 3.6058 | 108.49 KB |
