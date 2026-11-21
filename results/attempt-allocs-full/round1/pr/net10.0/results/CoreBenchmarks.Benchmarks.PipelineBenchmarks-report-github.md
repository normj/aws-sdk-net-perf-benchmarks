```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.26 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.63 μs | 0.367 μs | 0.243 μs | 0.3255 |  10.41 KB |
| InvokeAsync_JsonPost                              | 15.69 μs | 0.106 μs | 0.063 μs | 0.3746 |  11.61 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.76 μs | 1.925 μs | 1.273 μs | 0.4032 |  12.87 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.37 μs | 0.132 μs | 0.079 μs | 0.4298 |  12.09 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 26.86 μs | 4.132 μs | 2.733 μs | 0.5106 |  14.55 KB |
