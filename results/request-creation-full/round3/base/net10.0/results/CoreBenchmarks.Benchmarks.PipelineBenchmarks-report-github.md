```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.69 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.18 μs | 0.143 μs | 0.094 μs | 0.3680 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.22 μs | 0.096 μs | 0.064 μs | 0.4256 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.95 μs | 2.927 μs | 1.936 μs | 0.4287 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.89 μs | 0.034 μs | 0.021 μs | 0.4143 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 26.39 μs | 2.487 μs | 1.645 μs | 0.4890 |  14.72 KB |
