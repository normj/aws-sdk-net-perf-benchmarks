```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.27 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 14.61 μs | 0.440 μs | 0.157 μs | 0.3561 |  10.51 KB |
| InvokeAsync_JsonPost          | 16.51 μs | 0.585 μs | 0.209 μs | 0.3870 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding | 29.54 μs | 3.867 μs | 1.379 μs | 0.4425 |  13.04 KB |
