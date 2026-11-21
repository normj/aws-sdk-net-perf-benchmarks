```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.58 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.49 μs | 0.097 μs | 0.064 μs | 0.3494 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.73 μs | 0.089 μs | 0.053 μs | 0.4120 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 20.20 μs | 1.042 μs | 0.620 μs | 0.3783 |  11.92 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.99 μs | 0.038 μs | 0.020 μs | 0.3920 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.56 μs | 1.325 μs | 0.693 μs | 0.4562 |   13.7 KB |
