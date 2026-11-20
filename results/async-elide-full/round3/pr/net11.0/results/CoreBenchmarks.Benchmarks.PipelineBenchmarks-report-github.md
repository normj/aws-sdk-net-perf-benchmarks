```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 12.25 μs | 0.048 μs | 0.028 μs | 0.3448 |  10.51 KB |
| InvokeAsync_JsonPost          | 14.32 μs | 0.085 μs | 0.057 μs | 0.4017 |  11.48 KB |
| InvokeAsync_JsonPost_Yielding | 19.10 μs | 0.395 μs | 0.206 μs | 0.3806 |  11.66 KB |
