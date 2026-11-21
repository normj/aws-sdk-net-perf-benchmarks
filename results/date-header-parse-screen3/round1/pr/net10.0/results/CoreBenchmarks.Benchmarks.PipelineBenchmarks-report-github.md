```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.62 μs | 0.223 μs | 0.058 μs | 0.3566 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.98 μs | 0.907 μs | 0.323 μs | 0.4143 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 20.53 μs | 2.432 μs | 0.867 μs | 0.4134 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.66 μs | 0.910 μs | 0.325 μs | 0.4021 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.28 μs | 5.818 μs | 2.075 μs | 0.4318 |  14.72 KB |
