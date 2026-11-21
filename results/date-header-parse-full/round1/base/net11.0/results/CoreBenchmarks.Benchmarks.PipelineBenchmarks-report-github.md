```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.84 μs | 0.285 μs | 0.188 μs | 0.3640 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.93 μs | 0.528 μs | 0.350 μs | 0.4167 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 22.43 μs | 0.741 μs | 0.441 μs | 0.4322 |  11.98 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.97 μs | 0.367 μs | 0.243 μs | 0.4093 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 24.66 μs | 0.716 μs | 0.474 μs | 0.4890 |  13.81 KB |
