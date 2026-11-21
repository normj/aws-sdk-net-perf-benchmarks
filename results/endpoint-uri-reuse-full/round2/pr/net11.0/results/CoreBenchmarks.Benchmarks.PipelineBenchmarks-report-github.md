```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.1 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| EndpointRules_InvokeSync_JsonPost           | 12.18 μs | 0.073 μs | 0.044 μs | 0.3391 |  10.59 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding | 19.13 μs | 0.389 μs | 0.257 μs | 0.3761 |   12.1 KB |
