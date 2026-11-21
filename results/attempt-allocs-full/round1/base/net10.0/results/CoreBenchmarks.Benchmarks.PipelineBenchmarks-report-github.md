```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.55 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.15 μs | 0.111 μs | 0.066 μs | 0.3695 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.31 μs | 0.156 μs | 0.093 μs | 0.3662 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 21.22 μs | 0.816 μs | 0.486 μs | 0.4643 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.12 μs | 0.051 μs | 0.030 μs | 0.4215 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 26.36 μs | 2.401 μs | 1.429 μs | 0.4815 |  14.72 KB |
