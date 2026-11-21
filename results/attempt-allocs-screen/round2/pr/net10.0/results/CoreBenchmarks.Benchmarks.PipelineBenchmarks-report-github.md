```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.97 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.07 μs | 0.077 μs | 0.020 μs | 0.3695 |  10.41 KB |
| InvokeAsync_JsonPost                              | 15.54 μs | 0.184 μs | 0.066 μs | 0.3713 |  11.61 KB |
| InvokeAsync_JsonPost_Yielding                     | 21.72 μs | 4.383 μs | 1.563 μs | 0.3799 |  12.87 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.78 μs | 0.160 μs | 0.057 μs | 0.4116 |  12.09 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.40 μs | 4.083 μs | 1.456 μs | 0.5115 |  14.55 KB |
