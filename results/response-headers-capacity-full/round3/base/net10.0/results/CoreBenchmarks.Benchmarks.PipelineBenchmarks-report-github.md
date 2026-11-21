```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.23 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 14.04 μs | 0.106 μs | 0.070 μs | 0.3394 |  10.51 KB |
| InvokeAsync_JsonPost                              | 16.06 μs | 0.124 μs | 0.074 μs | 0.3819 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 32.95 μs | 3.853 μs | 2.549 μs | 0.4310 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.63 μs | 0.073 μs | 0.043 μs | 0.4379 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 39.16 μs | 2.935 μs | 1.941 μs | 0.5308 |  14.72 KB |
