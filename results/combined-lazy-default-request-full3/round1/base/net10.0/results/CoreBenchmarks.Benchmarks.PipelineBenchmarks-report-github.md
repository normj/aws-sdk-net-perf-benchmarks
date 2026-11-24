```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.28 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.45 μs | 0.062 μs | 0.041 μs | 0.3781 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.89 μs | 0.361 μs | 0.239 μs | 0.3780 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  23.00 μs | 2.245 μs | 1.485 μs | 0.4395 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  15.17 μs | 0.067 μs | 0.040 μs | 0.4268 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  27.43 μs | 1.945 μs | 1.286 μs | 0.4433 |  14.72 KB |
| InvokeSync_ServiceError                           |  60.01 μs | 1.508 μs | 0.998 μs | 1.4535 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 251.87 μs | 2.929 μs | 1.743 μs | 3.0242 | 108.71 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.79 μs | 0.238 μs | 0.142 μs | 0.3828 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  25.02 μs | 1.949 μs | 1.019 μs | 0.4756 |  13.53 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.72 μs | 0.091 μs | 0.047 μs | 0.3613 |  11.17 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  31.30 μs | 4.141 μs | 2.739 μs | 0.3842 |   13.7 KB |
