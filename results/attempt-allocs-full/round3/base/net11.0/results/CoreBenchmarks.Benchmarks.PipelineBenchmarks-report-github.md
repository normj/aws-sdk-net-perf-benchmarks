```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.44 μs | 0.103 μs | 0.068 μs | 0.3469 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.42 μs | 0.076 μs | 0.050 μs | 0.4029 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 19.39 μs | 0.150 μs | 0.089 μs | 0.3858 |  11.98 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.91 μs | 0.086 μs | 0.057 μs | 0.3872 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.00 μs | 0.096 μs | 0.057 μs | 0.4212 |  13.72 KB |
