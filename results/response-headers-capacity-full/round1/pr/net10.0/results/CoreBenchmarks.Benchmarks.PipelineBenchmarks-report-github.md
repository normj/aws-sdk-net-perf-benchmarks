```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.37 μs | 0.042 μs | 0.028 μs | 0.3759 |   10.4 KB |
| InvokeAsync_JsonPost                              | 15.53 μs | 0.117 μs | 0.077 μs | 0.3731 |  11.66 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.78 μs | 1.903 μs | 1.259 μs | 0.4189 |  12.93 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 15.07 μs | 0.091 μs | 0.054 μs | 0.4207 |  11.67 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.58 μs | 2.088 μs | 1.381 μs | 0.5000 |   14.2 KB |
