```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.08 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.49 μs | 0.070 μs | 0.037 μs | 0.3525 |   10.4 KB |
| InvokeAsync_JsonPost                              | 14.28 μs | 0.050 μs | 0.030 μs | 0.3995 |  11.66 KB |
| InvokeAsync_JsonPost_Yielding                     | 20.65 μs | 1.329 μs | 0.879 μs | 0.3941 |  11.86 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.89 μs | 0.050 μs | 0.030 μs | 0.3885 |  11.67 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 22.20 μs | 1.115 μs | 0.664 μs | 0.4823 |  13.32 KB |
