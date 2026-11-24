```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.12 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.87 μs | 0.256 μs | 0.169 μs | 0.3592 |  10.05 KB |
| InvokeAsync_JsonPost                              |  15.60 μs | 0.108 μs | 0.064 μs | 0.3634 |  11.32 KB |
| InvokeAsync_JsonPost_Yielding                     |  21.83 μs | 2.296 μs | 1.518 μs | 0.4101 |  12.59 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.64 μs | 0.118 μs | 0.070 μs | 0.4066 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  25.86 μs | 1.475 μs | 0.976 μs | 0.4692 |  14.27 KB |
| InvokeSync_ServiceError                           |  57.43 μs | 0.723 μs | 0.430 μs | 1.3889 |  43.91 KB |
| InvokeAsync_ServiceError_Yielding                 | 251.08 μs | 2.703 μs | 1.788 μs | 2.9762 | 108.03 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.42 μs | 0.177 μs | 0.105 μs | 0.3746 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  23.02 μs | 2.098 μs | 1.388 μs | 0.4706 |  13.08 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.87 μs | 0.139 μs | 0.083 μs | 0.3345 |  10.72 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  23.85 μs | 2.196 μs | 1.453 μs | 0.4643 |  13.25 KB |
