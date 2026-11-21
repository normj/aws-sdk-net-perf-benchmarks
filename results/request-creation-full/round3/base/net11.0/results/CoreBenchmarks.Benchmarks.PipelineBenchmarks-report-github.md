```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.67 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.38 μs | 0.073 μs | 0.048 μs | 0.3475 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.10 μs | 0.046 μs | 0.028 μs | 0.3952 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 20.68 μs | 2.408 μs | 1.593 μs | 0.3816 |  11.91 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.81 μs | 0.085 μs | 0.051 μs | 0.3872 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.33 μs | 0.592 μs | 0.352 μs | 0.4275 |   13.7 KB |
