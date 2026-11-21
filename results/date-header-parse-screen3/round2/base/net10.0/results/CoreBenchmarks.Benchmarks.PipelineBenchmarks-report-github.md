```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.62 μs | 0.939 μs | 0.335 μs | 0.3788 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.74 μs | 1.218 μs | 0.434 μs | 0.3691 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 21.96 μs | 1.802 μs | 0.643 μs | 0.4377 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.91 μs | 0.184 μs | 0.048 μs | 0.4191 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 26.71 μs | 6.566 μs | 1.705 μs | 0.4371 |  14.72 KB |
