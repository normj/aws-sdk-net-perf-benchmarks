```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.12 μs | 0.121 μs | 0.080 μs | 0.3673 |  10.41 KB |
| InvokeAsync_JsonPost                              | 15.30 μs | 0.089 μs | 0.059 μs | 0.3659 |  11.61 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.58 μs | 2.145 μs | 1.419 μs | 0.4039 |  12.88 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.99 μs | 0.037 μs | 0.022 μs | 0.4195 |  12.09 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 26.63 μs | 1.337 μs | 0.884 μs | 0.4945 |  14.55 KB |
