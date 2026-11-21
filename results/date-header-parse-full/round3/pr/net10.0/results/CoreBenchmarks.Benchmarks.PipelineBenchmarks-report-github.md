```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.66 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.34 μs | 0.037 μs | 0.019 μs | 0.3456 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.46 μs | 0.140 μs | 0.092 μs | 0.4036 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.39 μs | 2.635 μs | 1.743 μs | 0.4080 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.05 μs | 0.087 μs | 0.052 μs | 0.3963 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.39 μs | 2.993 μs | 1.980 μs | 0.4529 |  14.72 KB |
