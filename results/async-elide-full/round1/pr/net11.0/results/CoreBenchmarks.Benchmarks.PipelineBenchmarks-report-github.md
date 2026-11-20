```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 12.34 μs | 0.077 μs | 0.051 μs | 0.3494 |  10.51 KB |
| InvokeAsync_JsonPost          | 14.27 μs | 0.057 μs | 0.030 μs | 0.3992 |  11.48 KB |
| InvokeAsync_JsonPost_Yielding | 19.79 μs | 1.610 μs | 1.065 μs | 0.3825 |  11.63 KB |
