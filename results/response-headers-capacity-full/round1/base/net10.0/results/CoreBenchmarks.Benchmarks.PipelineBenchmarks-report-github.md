```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 14.31 μs | 0.457 μs | 0.302 μs | 0.3651 |  10.51 KB |
| InvokeAsync_JsonPost                              | 16.48 μs | 1.025 μs | 0.678 μs | 0.3758 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 24.98 μs | 5.198 μs | 3.438 μs | 0.4426 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.47 μs | 0.422 μs | 0.251 μs | 0.3834 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 33.07 μs | 3.192 μs | 2.111 μs | 0.5306 |  14.72 KB |
