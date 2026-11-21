```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.26 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.45 μs | 0.187 μs | 0.111 μs | 0.3483 |  10.41 KB |
| InvokeAsync_JsonPost                              | 14.18 μs | 0.046 μs | 0.027 μs | 0.3981 |  11.61 KB |
| InvokeAsync_JsonPost_Yielding                     | 19.02 μs | 0.176 μs | 0.105 μs | 0.3660 |  11.76 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.05 μs | 0.051 μs | 0.027 μs | 0.3934 |  12.09 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 22.62 μs | 2.096 μs | 1.386 μs | 0.4189 |  13.51 KB |
