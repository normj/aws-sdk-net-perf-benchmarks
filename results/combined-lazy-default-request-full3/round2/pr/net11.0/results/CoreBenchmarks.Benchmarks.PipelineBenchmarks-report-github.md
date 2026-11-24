```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|-------------------------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost                               |  11.86 μs |  0.054 μs |  0.028 μs | 0.3317 |  10.05 KB |
| InvokeAsync_JsonPost                              |  13.87 μs |  0.100 μs |  0.066 μs | 0.3910 |  11.31 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.06 μs |  0.160 μs |  0.095 μs | 0.3872 |  11.55 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  13.47 μs |  0.074 μs |  0.049 μs | 0.3762 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.05 μs |  1.301 μs |  0.861 μs | 0.4269 |  13.44 KB |
| InvokeSync_ServiceError                           |  51.11 μs |  0.278 μs |  0.184 μs | 1.4297 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 241.11 μs | 21.409 μs | 14.161 μs | 3.5714 | 108.14 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.09 μs |  0.079 μs |  0.052 μs | 0.3368 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  19.54 μs |  0.210 μs |  0.125 μs | 0.3882 |  12.05 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  12.78 μs |  0.087 μs |  0.058 μs | 0.3592 |  10.71 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  20.59 μs |  0.453 μs |  0.270 μs | 0.4080 |  12.29 KB |
