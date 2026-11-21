```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.21 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |---------:|---------:|---------:|-------:|----------:|
| EndpointDiscovery_InvokeSync_JsonPost           | 12.93 μs | 0.028 μs | 0.015 μs | 0.3637 |  11.13 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding | 20.75 μs | 1.695 μs | 1.009 μs | 0.4048 |  12.56 KB |
