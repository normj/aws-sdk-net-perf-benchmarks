```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.31 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 14.28 μs | 0.639 μs | 0.423 μs | 0.3316 |  10.51 KB |
| InvokeAsync_JsonPost                              | 16.19 μs | 0.314 μs | 0.187 μs | 0.4067 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 26.79 μs | 2.344 μs | 1.395 μs | 0.4310 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 16.06 μs | 0.408 μs | 0.243 μs | 0.4323 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 31.47 μs | 2.891 μs | 1.912 μs | 0.4664 |  14.72 KB |
