```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.14 μs | 0.412 μs | 0.147 μs | 0.3676 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.29 μs | 0.321 μs | 0.114 μs | 0.4252 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 24.71 μs | 1.784 μs | 0.636 μs | 0.4212 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.12 μs | 0.308 μs | 0.110 μs | 0.4235 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.62 μs | 2.758 μs | 0.984 μs | 0.4823 |  14.72 KB |
