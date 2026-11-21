```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.83 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.06 μs | 0.357 μs | 0.127 μs | 0.3673 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.51 μs | 0.518 μs | 0.185 μs | 0.3709 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 23.33 μs | 3.105 μs | 1.107 μs | 0.4304 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.69 μs | 0.172 μs | 0.061 μs | 0.4112 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.93 μs | 4.743 μs | 1.691 μs | 0.4960 |  14.72 KB |
