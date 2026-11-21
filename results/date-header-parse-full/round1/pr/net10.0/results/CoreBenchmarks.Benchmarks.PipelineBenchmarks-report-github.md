```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.24 μs | 0.411 μs | 0.245 μs | 0.3765 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.00 μs | 0.092 μs | 0.061 μs | 0.4163 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 26.83 μs | 3.145 μs | 2.080 μs | 0.3888 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.93 μs | 0.628 μs | 0.415 μs | 0.4171 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 29.80 μs | 3.577 μs | 2.366 μs | 0.4808 |  14.72 KB |
