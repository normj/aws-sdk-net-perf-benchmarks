```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.55 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.17 μs | 0.084 μs | 0.050 μs | 0.3418 |  10.32 KB |
| InvokeAsync_JsonPost                              | 14.00 μs | 0.086 μs | 0.045 μs | 0.3906 |  11.58 KB |
| InvokeAsync_JsonPost_Yielding                     | 18.51 μs | 0.083 μs | 0.044 μs | 0.3720 |  11.73 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.72 μs | 0.096 μs | 0.063 μs | 0.3841 |     12 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 21.36 μs | 1.010 μs | 0.668 μs | 0.4915 |  13.54 KB |
