```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.17 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 12.22 μs | 0.079 μs | 0.052 μs | 0.3418 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.30 μs | 0.171 μs | 0.113 μs | 0.3977 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 18.85 μs | 0.085 μs | 0.056 μs | 0.3806 |  11.91 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.91 μs | 0.084 μs | 0.055 μs | 0.3906 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 22.92 μs | 2.914 μs | 1.927 μs | 0.4167 |  13.61 KB |
