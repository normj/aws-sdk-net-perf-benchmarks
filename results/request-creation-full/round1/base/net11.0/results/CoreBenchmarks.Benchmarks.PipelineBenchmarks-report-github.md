```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.21 μs | 0.306 μs | 0.182 μs | 0.3399 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.15 μs | 0.107 μs | 0.064 μs | 0.3970 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 19.30 μs | 0.520 μs | 0.344 μs | 0.3901 |  11.93 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.83 μs | 0.051 μs | 0.030 μs | 0.3882 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.54 μs | 0.392 μs | 0.233 μs | 0.4293 |  13.78 KB |
