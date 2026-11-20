```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.34 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 14.40 μs | 3.931 μs | 2.600 μs | 0.3616 |  10.51 KB |
| InvokeAsync_JsonPost          | 14.50 μs | 0.353 μs | 0.210 μs | 0.4014 |  11.48 KB |
| InvokeAsync_JsonPost_Yielding | 20.05 μs | 1.157 μs | 0.688 μs | 0.3592 |  11.64 KB |
