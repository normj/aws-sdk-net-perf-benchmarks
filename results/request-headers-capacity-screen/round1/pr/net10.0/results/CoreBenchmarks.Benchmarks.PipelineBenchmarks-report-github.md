```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.58 μs |  0.393 μs | 0.102 μs | 0.3264 |  10.13 KB |
| InvokeAsync_JsonPost                              |  15.64 μs |  1.072 μs | 0.382 μs | 0.3698 |   11.4 KB |
| InvokeAsync_JsonPost_Yielding                     |  27.40 μs |  3.771 μs | 1.345 μs | 0.4195 |  12.66 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.68 μs |  0.918 μs | 0.327 μs | 0.4264 |  11.81 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  30.21 μs |  5.704 μs | 2.034 μs | 0.4521 |  14.34 KB |
| InvokeSync_ServiceError                           |  59.60 μs |  1.991 μs | 0.517 μs | 1.4423 |  43.87 KB |
| InvokeAsync_ServiceError_Yielding                 | 293.80 μs | 10.677 μs | 3.808 μs | 3.4722 | 108.06 KB |
