```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.20 μs | 0.242 μs | 0.063 μs | 0.3683 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.40 μs | 0.180 μs | 0.064 μs | 0.3684 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 21.81 μs | 4.143 μs | 1.477 μs | 0.4263 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.97 μs | 3.099 μs | 1.105 μs | 0.4139 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 26.80 μs | 1.919 μs | 0.684 μs | 0.5106 |  14.72 KB |
