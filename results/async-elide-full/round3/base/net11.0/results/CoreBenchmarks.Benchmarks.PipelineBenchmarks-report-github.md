```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.33 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 14.57 μs | 3.667 μs | 2.425 μs | 0.3631 |  10.51 KB |
| InvokeAsync_JsonPost          | 22.66 μs | 6.792 μs | 3.552 μs | 0.3811 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding | 43.43 μs | 7.086 μs | 3.706 μs | 0.3463 |  12.92 KB |
