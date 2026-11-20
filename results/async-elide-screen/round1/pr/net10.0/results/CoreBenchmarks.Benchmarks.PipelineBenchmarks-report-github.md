```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                        | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------ |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost           | 14.46 μs | 0.539 μs | 0.192 μs | 0.3422 |  10.51 KB |
| InvokeAsync_JsonPost          | 16.62 μs | 0.238 μs | 0.062 μs | 0.3947 |  11.49 KB |
| InvokeAsync_JsonPost_Yielding | 28.18 μs | 5.400 μs | 1.926 μs | 0.3585 |  12.54 KB |
