```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.25 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.44 μs | 0.099 μs | 0.065 μs | 0.3733 |   10.4 KB |
| InvokeAsync_JsonPost                              | 15.61 μs | 0.300 μs | 0.198 μs | 0.3676 |  11.66 KB |
| InvokeAsync_JsonPost_Yielding                     | 21.47 μs | 1.238 μs | 0.819 μs | 0.4027 |  12.93 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.28 μs | 0.061 μs | 0.041 μs | 0.4231 |  11.67 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.07 μs | 2.249 μs | 1.488 μs | 0.4664 |   14.2 KB |
