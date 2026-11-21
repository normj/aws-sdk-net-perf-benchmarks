```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.92 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.56 μs | 0.067 μs | 0.040 μs | 0.3791 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.49 μs | 0.133 μs | 0.069 μs | 0.3687 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 24.81 μs | 2.635 μs | 1.743 μs | 0.4414 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 19.99 μs | 3.349 μs | 2.215 μs | 0.4349 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 28.90 μs | 7.356 μs | 4.865 μs | 0.4454 |  14.72 KB |
