```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.07 μs | 0.578 μs | 0.150 μs | 0.3664 |   10.4 KB |
| InvokeAsync_JsonPost                              | 15.29 μs | 0.345 μs | 0.123 μs | 0.3637 |  11.66 KB |
| InvokeAsync_JsonPost_Yielding                     | 21.06 μs | 1.959 μs | 0.699 μs | 0.4721 |  12.93 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.74 μs | 0.186 μs | 0.066 μs | 0.4127 |  11.67 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.25 μs | 3.699 μs | 1.319 μs | 0.5157 |   14.2 KB |
