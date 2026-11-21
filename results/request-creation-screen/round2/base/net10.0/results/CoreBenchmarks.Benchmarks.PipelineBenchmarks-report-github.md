```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 14.43 μs | 0.632 μs | 0.225 μs | 0.3498 |  10.51 KB |
| InvokeAsync_JsonPost                              | 16.83 μs | 0.983 μs | 0.255 μs | 0.3989 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 29.02 μs | 5.769 μs | 2.057 μs | 0.4355 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 16.59 μs | 0.316 μs | 0.082 μs | 0.3914 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 32.49 μs | 7.388 μs | 2.635 μs | 0.4912 |  14.72 KB |
