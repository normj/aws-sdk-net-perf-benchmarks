```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| EndpointRules_InvokeSync_JsonPost           | 13.34 μs | 0.055 μs | 0.033 μs | 0.3720 |  10.59 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding | 23.57 μs | 2.500 μs | 1.654 μs | 0.4358 |  13.12 KB |
