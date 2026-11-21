```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.25 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.29 μs | 0.141 μs | 0.094 μs | 0.3701 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.29 μs | 0.101 μs | 0.067 μs | 0.3680 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 23.07 μs | 2.205 μs | 1.459 μs | 0.4749 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.09 μs | 0.602 μs | 0.358 μs | 0.4379 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.72 μs | 2.387 μs | 1.579 μs | 0.4815 |  14.72 KB |
