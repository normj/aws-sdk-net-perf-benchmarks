```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.09 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| EndpointRules_InvokeSync_JsonPost           | 13.68 μs | 0.339 μs | 0.224 μs | 0.3775 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding | 24.75 μs | 2.713 μs | 1.615 μs | 0.4395 |  13.53 KB |
