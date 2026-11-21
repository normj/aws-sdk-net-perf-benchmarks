```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.62 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.18 μs | 0.067 μs | 0.040 μs | 0.3714 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.29 μs | 0.515 μs | 0.306 μs | 0.4252 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.77 μs | 2.969 μs | 1.964 μs | 0.4549 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.97 μs | 0.373 μs | 0.247 μs | 0.4155 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.70 μs | 1.776 μs | 1.175 μs | 0.5357 |  14.72 KB |
