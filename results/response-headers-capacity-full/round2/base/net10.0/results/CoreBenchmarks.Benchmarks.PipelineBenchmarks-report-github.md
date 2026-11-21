```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.15 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.22 μs | 0.127 μs | 0.084 μs | 0.3704 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.11 μs | 0.089 μs | 0.053 μs | 0.4215 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.24 μs | 1.417 μs | 0.843 μs | 0.4001 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.86 μs | 0.184 μs | 0.122 μs | 0.4108 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.76 μs | 2.481 μs | 1.477 μs | 0.5208 |  14.72 KB |
