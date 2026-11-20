```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.45GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 13.67 μs | 0.149 μs | 0.098 μs | 0.3281 |  10.51 KB |
| InvokeAsync_JsonPost          | 15.71 μs | 0.168 μs | 0.100 μs | 0.3858 |  11.49 KB |
| InvokeAsync_JsonPost_Yielding | 23.49 μs | 2.471 μs | 1.471 μs | 0.4167 |  12.54 KB |
