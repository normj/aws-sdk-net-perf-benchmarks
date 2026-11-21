```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.2 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.24 μs | 0.053 μs | 0.035 μs | 0.3456 |   10.4 KB |
| InvokeAsync_JsonPost                              | 14.60 μs | 0.276 μs | 0.183 μs | 0.3885 |  11.66 KB |
| InvokeAsync_JsonPost_Yielding                     | 24.93 μs | 2.960 μs | 1.958 μs | 0.4167 |     12 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.73 μs | 0.155 μs | 0.102 μs | 0.4093 |  11.67 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 26.97 μs | 2.988 μs | 1.976 μs | 0.4318 |  13.28 KB |
