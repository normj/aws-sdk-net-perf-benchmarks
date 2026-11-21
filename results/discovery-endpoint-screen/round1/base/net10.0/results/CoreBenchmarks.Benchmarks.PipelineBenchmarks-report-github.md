```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 9.45 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |---------:|---------:|---------:|-------:|----------:|
| EndpointDiscovery_InvokeSync_JsonPost           | 14.24 μs | 0.220 μs | 0.057 μs | 0.3995 |  11.13 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding | 25.78 μs | 2.880 μs | 0.748 μs | 0.4685 |   13.7 KB |
