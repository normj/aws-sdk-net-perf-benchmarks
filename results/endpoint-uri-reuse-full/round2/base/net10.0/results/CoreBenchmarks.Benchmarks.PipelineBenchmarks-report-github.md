```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.03 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                      | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| EndpointRules_InvokeSync_JsonPost           | 13.73 μs | 0.272 μs | 0.162 μs | 0.3824 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding | 22.73 μs | 3.095 μs | 2.047 μs | 0.4529 |  13.53 KB |
