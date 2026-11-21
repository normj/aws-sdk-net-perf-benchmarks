```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.2 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.60 μs |  0.211 μs | 0.075 μs | 0.3319 |  10.32 KB |
| InvokeAsync_JsonPost                              | 16.65 μs |  1.069 μs | 0.381 μs | 0.3838 |  11.59 KB |
| InvokeAsync_JsonPost_Yielding                     | 33.08 μs |  4.287 μs | 1.529 μs | 0.4425 |  12.85 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 19.36 μs |  1.689 μs | 0.439 μs | 0.4116 |     12 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 44.26 μs | 13.684 μs | 3.554 μs | 0.4340 |  14.53 KB |
