```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.56 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  13.75 μs | 0.106 μs | 0.055 μs | 0.3298 |  10.05 KB |
| InvokeAsync_JsonPost                              |  15.67 μs | 0.123 μs | 0.081 μs | 0.3758 |  11.32 KB |
| InvokeAsync_JsonPost_Yielding                     |  34.98 μs | 2.136 μs | 1.413 μs | 0.4223 |  12.59 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  16.28 μs | 0.043 μs | 0.022 μs | 0.3890 |  11.73 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  38.76 μs | 3.000 μs | 1.984 μs | 0.4947 |  14.27 KB |
| InvokeSync_ServiceError                           |  62.36 μs | 0.271 μs | 0.162 μs | 1.4940 |   43.9 KB |
| InvokeAsync_ServiceError_Yielding                 | 316.41 μs | 4.287 μs | 2.551 μs | 3.8265 | 108.07 KB |
| EndpointRules_InvokeSync_JsonPost                 |  14.71 μs | 0.104 μs | 0.062 μs | 0.3524 |  10.55 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  36.68 μs | 3.281 μs | 2.170 μs | 0.4618 |  13.08 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  15.44 μs | 0.091 μs | 0.060 μs | 0.3695 |  10.72 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  38.36 μs | 1.496 μs | 0.891 μs | 0.4573 |  13.25 KB |
