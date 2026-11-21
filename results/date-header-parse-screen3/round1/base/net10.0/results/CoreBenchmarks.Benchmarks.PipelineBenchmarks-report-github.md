```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.46 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.29 μs | 0.321 μs | 0.083 μs | 0.3768 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.37 μs | 0.117 μs | 0.030 μs | 0.3735 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 23.59 μs | 7.595 μs | 2.708 μs | 0.4678 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.10 μs | 0.188 μs | 0.049 μs | 0.4277 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 27.14 μs | 6.040 μs | 2.154 μs | 0.5032 |  14.72 KB |
