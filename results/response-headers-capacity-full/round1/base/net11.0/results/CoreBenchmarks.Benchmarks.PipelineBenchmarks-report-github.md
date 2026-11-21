```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean     | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |---------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               | 13.02 μs |  0.144 μs | 0.086 μs | 0.3680 |  10.51 KB |
| InvokeAsync_JsonPost                              | 14.89 μs |  0.185 μs | 0.110 μs | 0.4195 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     | 31.00 μs | 10.336 μs | 6.837 μs | 0.3606 |  12.03 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           | 13.95 μs |  0.329 μs | 0.172 μs | 0.3966 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding | 23.60 μs |  2.218 μs | 1.467 μs | 0.4800 |  13.77 KB |
