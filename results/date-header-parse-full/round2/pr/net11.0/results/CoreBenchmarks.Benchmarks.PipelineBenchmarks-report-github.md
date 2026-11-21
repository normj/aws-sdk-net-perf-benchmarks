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
| InvokeSync_JsonPost                               | 11.52 μs | 0.069 μs | 0.041 μs | 0.3687 |  10.51 KB |
| InvokeAsync_JsonPost                              | 13.62 μs | 0.034 μs | 0.018 μs | 0.3821 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 18.60 μs | 1.094 μs | 0.651 μs | 0.3676 |  11.92 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.10 μs | 0.096 μs | 0.063 μs | 0.4163 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 20.18 μs | 0.142 μs | 0.094 μs | 0.4814 |  13.67 KB |
