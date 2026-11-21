```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.36 μs | 0.115 μs | 0.041 μs | 0.3469 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.52 μs | 0.193 μs | 0.050 μs | 0.4081 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 21.23 μs | 6.013 μs | 2.144 μs | 0.4156 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.15 μs | 0.065 μs | 0.017 μs | 0.3956 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.14 μs | 4.418 μs | 1.575 μs | 0.5304 |  14.72 KB |
