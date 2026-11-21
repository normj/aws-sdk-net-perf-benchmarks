```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.35 μs | 0.099 μs | 0.059 μs | 0.3708 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.50 μs | 0.232 μs | 0.154 μs | 0.3720 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.52 μs | 1.840 μs | 1.217 μs | 0.3986 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.14 μs | 0.083 μs | 0.049 μs | 0.4227 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.94 μs | 2.412 μs | 1.595 μs | 0.5008 |  14.72 KB |
