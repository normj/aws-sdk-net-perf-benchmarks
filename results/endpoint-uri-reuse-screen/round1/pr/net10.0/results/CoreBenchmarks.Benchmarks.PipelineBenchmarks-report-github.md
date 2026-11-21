```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| EndpointRules_InvokeSync_JsonPost           | 12.68 μs | 0.132 μs | 0.047 μs | 0.3554 |  10.59 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding | 22.21 μs | 2.482 μs | 0.645 μs | 0.4200 |  13.12 KB |
