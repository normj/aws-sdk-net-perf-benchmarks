```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.64 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.28 μs | 0.070 μs | 0.046 μs | 0.3695 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.49 μs | 0.163 μs | 0.097 μs | 0.3750 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.48 μs | 2.212 μs | 1.463 μs | 0.4200 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.94 μs | 0.062 μs | 0.037 μs | 0.4215 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 26.17 μs | 2.522 μs | 1.668 μs | 0.5165 |  14.72 KB |
