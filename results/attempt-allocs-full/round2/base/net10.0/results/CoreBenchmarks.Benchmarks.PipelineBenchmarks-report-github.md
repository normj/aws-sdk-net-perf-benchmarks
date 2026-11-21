```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.24 μs | 0.094 μs | 0.056 μs | 0.3698 |  10.51 KB |
| InvokeAsync_JsonPost                              | 15.42 μs | 0.081 μs | 0.048 μs | 0.3687 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.00 μs | 1.427 μs | 0.944 μs | 0.4304 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.84 μs | 0.063 μs | 0.042 μs | 0.4163 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 25.94 μs | 1.788 μs | 1.183 μs | 0.4692 |  14.72 KB |
