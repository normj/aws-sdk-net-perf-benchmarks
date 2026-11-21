```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.37 μs | 0.168 μs | 0.060 μs | 0.3765 |   10.4 KB |
| InvokeAsync_JsonPost                              | 16.05 μs | 1.914 μs | 0.682 μs | 0.3695 |  11.66 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.33 μs | 5.453 μs | 1.945 μs | 0.4183 |  12.93 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.24 μs | 0.293 μs | 0.104 μs | 0.3634 |  11.67 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.32 μs | 3.630 μs | 1.294 μs | 0.4378 |   14.2 KB |
