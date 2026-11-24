```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.62 μs |  2.920 μs | 1.738 μs | 0.3574 |  10.05 KB |
| InvokeAsync_JsonPost                              |  15.06 μs |  0.077 μs | 0.046 μs | 0.3616 |  11.32 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.55 μs |  2.265 μs | 1.498 μs | 0.4085 |  12.58 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.94 μs |  0.165 μs | 0.109 μs | 0.4123 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.12 μs |  2.233 μs | 1.477 μs | 0.4952 |  14.27 KB |
| InvokeSync_ServiceError                           |  61.37 μs | 13.236 μs | 7.876 μs | 1.3686 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 252.59 μs |  2.807 μs | 1.857 μs | 3.0242 | 108.03 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.54 μs |  0.159 μs | 0.105 μs | 0.3804 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  23.30 μs |  3.397 μs | 2.247 μs | 0.4139 |  13.08 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.21 μs |  0.188 μs | 0.125 μs | 0.3406 |  10.72 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  23.55 μs |  1.781 μs | 1.178 μs | 0.4786 |  13.25 KB |
