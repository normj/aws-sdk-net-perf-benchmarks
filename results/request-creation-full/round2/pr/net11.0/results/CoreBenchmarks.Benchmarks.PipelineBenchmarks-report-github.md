```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.64 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.11 μs | 0.030 μs | 0.016 μs | 0.3421 |  10.32 KB |
| InvokeAsync_JsonPost                              | 14.23 μs | 0.096 μs | 0.057 μs | 0.3970 |  11.58 KB |
| InvokeAsync_JsonPost_Yielding                     | 19.48 μs | 0.611 μs | 0.319 μs | 0.4096 |  11.77 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.78 μs | 0.077 μs | 0.051 μs | 0.3858 |     12 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.39 μs | 0.112 μs | 0.067 μs | 0.4269 |  13.62 KB |
