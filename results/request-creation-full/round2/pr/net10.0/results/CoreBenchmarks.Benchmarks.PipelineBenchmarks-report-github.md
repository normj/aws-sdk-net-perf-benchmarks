```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.68 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.29 μs | 0.219 μs | 0.130 μs | 0.3698 |  10.32 KB |
| InvokeAsync_JsonPost                              | 15.11 μs | 0.088 μs | 0.053 μs | 0.3634 |  11.59 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.49 μs | 2.410 μs | 1.594 μs | 0.4229 |  12.85 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.86 μs | 0.125 μs | 0.074 μs | 0.4143 |     12 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.91 μs | 2.430 μs | 1.608 μs | 0.4860 |  14.53 KB |
