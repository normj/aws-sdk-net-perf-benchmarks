```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.92 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.96 μs | 0.114 μs | 0.075 μs | 0.3640 |   10.1 KB |
| InvokeAsync_JsonPost                              |  15.43 μs | 0.132 μs | 0.087 μs | 0.3684 |  11.37 KB |
| InvokeAsync_JsonPost_Yielding                     |  23.13 μs | 2.395 μs | 1.584 μs | 0.4334 |  12.63 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.03 μs | 0.118 μs | 0.078 μs | 0.4187 |  11.78 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.59 μs | 1.712 μs | 1.132 μs | 0.4464 |  14.31 KB |
| InvokeSync_ServiceError                           |  58.13 μs | 0.664 μs | 0.395 μs | 1.3889 |  43.83 KB |
| InvokeAsync_ServiceError_Yielding                 | 258.72 μs | 3.031 μs | 2.005 μs | 3.0738 | 108.01 KB |
