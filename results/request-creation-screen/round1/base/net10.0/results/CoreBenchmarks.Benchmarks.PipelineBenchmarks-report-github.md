```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.23 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.97 μs | 0.329 μs | 0.117 μs | 0.3342 |  10.51 KB |
| InvokeAsync_JsonPost                              | 16.74 μs | 0.937 μs | 0.334 μs | 0.3902 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 27.00 μs | 6.115 μs | 2.181 μs | 0.4188 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.72 μs | 0.424 μs | 0.151 μs | 0.4362 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 36.42 μs | 7.309 μs | 2.606 μs | 0.4103 |  14.72 KB |
