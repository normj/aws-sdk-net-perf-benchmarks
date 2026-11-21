```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.08 μs | 0.328 μs | 0.117 μs | 0.3661 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.12 μs | 0.148 μs | 0.039 μs | 0.4239 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.57 μs | 5.840 μs | 2.082 μs | 0.4334 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.69 μs | 0.147 μs | 0.052 μs | 0.4100 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.60 μs | 5.382 μs | 1.919 μs | 0.5191 |  14.72 KB |
