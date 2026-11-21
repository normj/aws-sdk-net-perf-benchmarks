```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 10.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |---------:|---------:|---------:|-------:|----------:|
| EndpointDiscovery_InvokeSync_JsonPost           | 13.43 μs | 0.127 μs | 0.084 μs | 0.3238 |  10.38 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding | 21.07 μs | 1.024 μs | 0.535 μs | 0.4195 |  12.95 KB |
