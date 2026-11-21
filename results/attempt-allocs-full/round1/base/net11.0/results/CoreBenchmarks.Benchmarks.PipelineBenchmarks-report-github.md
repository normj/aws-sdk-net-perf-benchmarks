```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.55 μs | 0.024 μs | 0.014 μs | 0.3525 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.27 μs | 0.042 μs | 0.022 μs | 0.3985 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 18.69 μs | 0.117 μs | 0.061 μs | 0.3738 |  11.91 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.02 μs | 0.076 μs | 0.045 μs | 0.3927 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 22.57 μs | 2.276 μs | 1.355 μs | 0.4352 |  13.69 KB |
