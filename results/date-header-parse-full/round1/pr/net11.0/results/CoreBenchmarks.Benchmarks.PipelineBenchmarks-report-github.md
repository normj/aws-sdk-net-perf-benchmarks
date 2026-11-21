```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 11.68 μs | 0.105 μs | 0.055 μs | 0.3731 |  10.51 KB |
| InvokeAsync_JsonPost                              | 13.76 μs | 0.411 μs | 0.272 μs | 0.3801 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 19.51 μs | 2.114 μs | 1.398 μs | 0.4058 |  11.94 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.18 μs | 0.080 μs | 0.053 μs | 0.4237 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.32 μs | 1.140 μs | 0.679 μs | 0.4575 |  13.71 KB |
