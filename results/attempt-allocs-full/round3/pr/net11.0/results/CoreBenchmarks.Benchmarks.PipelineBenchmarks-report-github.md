```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.32 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.47 μs | 0.065 μs | 0.039 μs | 0.3494 |  10.41 KB |
| InvokeAsync_JsonPost                              | 14.28 μs | 0.045 μs | 0.027 μs | 0.4021 |  11.61 KB |
| InvokeAsync_JsonPost_Yielding                     | 18.90 μs | 0.303 μs | 0.180 μs | 0.3788 |  11.77 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 14.05 μs | 0.135 μs | 0.080 μs | 0.3927 |  12.09 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 20.85 μs | 0.369 μs | 0.244 μs | 0.4150 |  13.55 KB |
