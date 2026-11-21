```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.24 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.58 μs | 0.220 μs | 0.146 μs | 0.3497 |  10.41 KB |
| InvokeAsync_JsonPost                              | 14.23 μs | 0.132 μs | 0.087 μs | 0.3966 |  11.61 KB |
| InvokeAsync_JsonPost_Yielding                     | 18.98 μs | 0.121 μs | 0.072 μs | 0.3844 |   11.8 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.11 μs | 0.081 μs | 0.054 μs | 0.3952 |  12.09 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.88 μs | 2.412 μs | 1.595 μs | 0.4206 |  13.58 KB |
