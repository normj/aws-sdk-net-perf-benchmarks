```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.67 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 11.48 μs | 0.071 μs | 0.047 μs | 0.3701 |  10.51 KB |
| InvokeAsync_JsonPost                              | 13.74 μs | 0.033 μs | 0.017 μs | 0.3844 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 19.53 μs | 0.352 μs | 0.233 μs | 0.3516 |  12.01 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.26 μs | 0.055 μs | 0.033 μs | 0.4274 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.19 μs | 0.090 μs | 0.047 μs | 0.4252 |  13.95 KB |
