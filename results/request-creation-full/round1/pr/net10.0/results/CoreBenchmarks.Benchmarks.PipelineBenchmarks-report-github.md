```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.70 μs | 0.110 μs | 0.066 μs | 0.3704 |  10.32 KB |
| InvokeAsync_JsonPost                              | 14.89 μs | 0.093 μs | 0.055 μs | 0.4183 |  11.59 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.20 μs | 1.807 μs | 1.195 μs | 0.4139 |  12.85 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.69 μs | 0.045 μs | 0.024 μs | 0.4096 |     12 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.00 μs | 3.194 μs | 2.113 μs | 0.5090 |  14.53 KB |
