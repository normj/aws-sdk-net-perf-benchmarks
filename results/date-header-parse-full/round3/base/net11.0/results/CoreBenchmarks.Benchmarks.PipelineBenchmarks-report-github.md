```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.64 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.39 μs | 0.075 μs | 0.045 μs | 0.3497 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.20 μs | 0.037 μs | 0.019 μs | 0.3966 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 20.01 μs | 0.919 μs | 0.547 μs | 0.3976 |     12 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.99 μs | 0.040 μs | 0.024 μs | 0.3917 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.65 μs | 0.061 μs | 0.036 μs | 0.4764 |  13.83 KB |
