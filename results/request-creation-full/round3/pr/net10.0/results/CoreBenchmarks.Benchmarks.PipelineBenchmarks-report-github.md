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
| InvokeSync_JsonPost                               | 12.93 μs | 0.076 μs | 0.045 μs | 0.3631 |  10.32 KB |
| InvokeAsync_JsonPost                              | 15.47 μs | 0.158 μs | 0.094 μs | 0.3728 |  11.59 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.70 μs | 1.247 μs | 0.742 μs | 0.4085 |  12.85 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.68 μs | 0.059 μs | 0.035 μs | 0.4123 |     12 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.38 μs | 2.250 μs | 1.488 μs | 0.5208 |  14.53 KB |
