```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.21 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.19 μs | 0.059 μs | 0.035 μs | 0.3439 |   10.4 KB |
| InvokeAsync_JsonPost                              | 14.19 μs | 0.150 μs | 0.099 μs | 0.3963 |  11.66 KB |
| InvokeAsync_JsonPost_Yielding                     | 19.76 μs | 0.826 μs | 0.492 μs | 0.3981 |  11.92 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.83 μs | 0.131 μs | 0.086 μs | 0.3861 |  11.67 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.58 μs | 1.181 μs | 0.781 μs | 0.4206 |  13.34 KB |
