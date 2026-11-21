```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.89 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.80 μs | 0.026 μs | 0.016 μs | 0.3616 |   10.1 KB |
| InvokeAsync_JsonPost                              |  15.34 μs | 0.108 μs | 0.071 μs | 0.3666 |  11.37 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.84 μs | 2.450 μs | 1.620 μs | 0.3986 |  12.63 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.78 μs | 0.031 μs | 0.020 μs | 0.4175 |  11.78 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.17 μs | 1.488 μs | 0.984 μs | 0.4310 |  14.31 KB |
| InvokeSync_ServiceError                           |  57.61 μs | 0.485 μs | 0.289 μs | 1.3993 |  43.83 KB |
| InvokeAsync_ServiceError_Yielding                 | 252.43 μs | 2.686 μs | 1.598 μs | 3.0242 | 108.05 KB |
