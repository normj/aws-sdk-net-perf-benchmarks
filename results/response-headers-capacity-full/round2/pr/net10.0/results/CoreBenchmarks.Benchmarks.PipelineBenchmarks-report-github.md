```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.19 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.24 μs | 0.106 μs | 0.070 μs | 0.3683 |   10.4 KB |
| InvokeAsync_JsonPost                              | 15.24 μs | 0.191 μs | 0.114 μs | 0.3634 |  11.66 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.84 μs | 3.066 μs | 1.824 μs | 0.3803 |  12.93 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.71 μs | 0.102 μs | 0.068 μs | 0.4167 |  11.67 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.94 μs | 2.044 μs | 1.352 μs | 0.4195 |   14.2 KB |
