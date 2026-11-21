```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.68 μs |  0.651 μs |  0.232 μs | 0.3781 |  10.51 KB |
| InvokeAsync_JsonPost                              |  17.37 μs |  1.253 μs |  0.447 μs | 0.3985 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  29.06 μs |  4.354 μs |  1.553 μs | 0.4296 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  16.34 μs |  1.052 μs |  0.375 μs | 0.3994 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  34.08 μs |  8.991 μs |  3.206 μs | 0.4708 |  14.72 KB |
| InvokeSync_ServiceError                           |  63.70 μs |  3.159 μs |  1.126 μs | 1.4401 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 323.76 μs | 38.731 μs | 13.812 μs | 3.6058 | 108.49 KB |
