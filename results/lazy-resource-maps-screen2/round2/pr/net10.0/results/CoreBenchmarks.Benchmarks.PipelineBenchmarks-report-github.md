```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.83 μs |  1.206 μs | 0.313 μs | 0.3269 |  10.27 KB |
| InvokeAsync_JsonPost                              |  24.08 μs |  3.965 μs | 1.030 μs | 0.4174 |  11.54 KB |
| InvokeAsync_JsonPost_Yielding                     |  45.77 μs |  5.355 μs | 1.391 μs | 0.3582 |   12.8 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  27.79 μs | 20.529 μs | 7.321 μs | 0.4167 |  11.95 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  51.19 μs | 19.222 μs | 6.855 μs | 0.4281 |  14.48 KB |
| InvokeSync_ServiceError                           |  67.85 μs | 14.799 μs | 5.277 μs | 1.5756 |     44 KB |
| InvokeAsync_ServiceError_Yielding                 | 309.51 μs | 36.728 μs | 9.538 μs | 3.7500 | 108.25 KB |
