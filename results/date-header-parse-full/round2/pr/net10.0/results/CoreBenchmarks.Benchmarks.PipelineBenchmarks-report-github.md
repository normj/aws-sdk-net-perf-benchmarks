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
| InvokeSync_JsonPost                               | 12.53 μs | 0.059 μs | 0.039 μs | 0.3508 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.58 μs | 0.053 μs | 0.035 μs | 0.4108 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 21.50 μs | 2.894 μs | 1.914 μs | 0.4043 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.28 μs | 0.060 μs | 0.040 μs | 0.3992 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.98 μs | 1.981 μs | 1.310 μs | 0.4852 |  14.72 KB |
