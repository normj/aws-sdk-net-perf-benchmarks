```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.67 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.64 μs | 0.520 μs | 0.135 μs | 0.3255 |  10.32 KB |
| InvokeAsync_JsonPost                              | 16.06 μs | 0.919 μs | 0.328 μs | 0.3776 |  11.59 KB |
| InvokeAsync_JsonPost_Yielding                     | 25.77 μs | 4.353 μs | 1.552 μs | 0.3912 |  12.85 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.55 μs | 0.567 μs | 0.147 μs | 0.4306 |     12 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 30.74 μs | 3.509 μs | 1.251 μs | 0.4472 |  14.53 KB |
