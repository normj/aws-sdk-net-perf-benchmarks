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
| InvokeSync_JsonPost                               | 12.31 μs | 0.116 μs | 0.077 μs | 0.3448 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.25 μs | 0.064 μs | 0.038 μs | 0.4003 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 18.97 μs | 0.134 μs | 0.080 μs | 0.3779 |  11.91 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.85 μs | 0.109 μs | 0.072 μs | 0.4413 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 22.15 μs | 1.206 μs | 0.798 μs | 0.4183 |  13.67 KB |
