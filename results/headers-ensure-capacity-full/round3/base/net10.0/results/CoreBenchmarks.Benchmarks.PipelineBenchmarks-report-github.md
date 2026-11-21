```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.26 μs | 0.124 μs | 0.074 μs | 0.3768 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.57 μs | 0.043 μs | 0.022 μs | 0.3758 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  23.98 μs | 2.673 μs | 1.768 μs | 0.3805 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.29 μs | 0.071 μs | 0.042 μs | 0.4268 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  27.21 μs | 1.675 μs | 1.108 μs | 0.5217 |  14.72 KB |
| InvokeSync_ServiceError                           |  57.76 μs | 0.384 μs | 0.254 μs | 1.3941 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding                 | 259.37 μs | 2.394 μs | 1.425 μs | 3.0738 | 108.46 KB |
