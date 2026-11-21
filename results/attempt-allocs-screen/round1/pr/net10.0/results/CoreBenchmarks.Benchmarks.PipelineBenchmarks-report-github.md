```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.37 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.43 μs | 0.140 μs | 0.050 μs | 0.3759 |  10.41 KB |
| InvokeAsync_JsonPost                              | 15.77 μs | 0.402 μs | 0.143 μs | 0.3758 |  11.61 KB |
| InvokeAsync_JsonPost_Yielding                     | 23.31 μs | 4.388 μs | 1.565 μs | 0.4439 |  12.87 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.23 μs | 0.208 μs | 0.054 μs | 0.4252 |  12.09 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.15 μs | 3.008 μs | 0.781 μs | 0.5008 |  14.55 KB |
