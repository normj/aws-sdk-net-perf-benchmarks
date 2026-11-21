```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.23 μs | 0.111 μs | 0.066 μs | 0.3670 |  10.41 KB |
| InvokeAsync_JsonPost                              | 15.36 μs | 0.134 μs | 0.089 μs | 0.3673 |  11.61 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.58 μs | 3.184 μs | 2.106 μs | 0.4096 |  12.88 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.80 μs | 0.079 μs | 0.053 μs | 0.4211 |  12.09 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.00 μs | 2.024 μs | 1.339 μs | 0.4837 |  14.55 KB |
