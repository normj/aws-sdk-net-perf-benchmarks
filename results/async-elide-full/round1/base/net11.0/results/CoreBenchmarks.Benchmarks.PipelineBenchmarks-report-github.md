```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.89 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 12.43 μs | 0.069 μs | 0.041 μs | 0.3500 |  10.51 KB |
| InvokeAsync_JsonPost          | 14.68 μs | 0.079 μs | 0.047 μs | 0.4108 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding | 19.55 μs | 1.159 μs | 0.606 μs | 0.3825 |  11.93 KB |
