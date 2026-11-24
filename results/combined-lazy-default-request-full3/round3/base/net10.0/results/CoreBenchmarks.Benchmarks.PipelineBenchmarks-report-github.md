```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.95 μs | 0.065 μs | 0.039 μs | 0.3622 |  10.51 KB |
| InvokeAsync_JsonPost                              |  15.35 μs | 0.522 μs | 0.345 μs | 0.4211 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  22.21 μs | 2.800 μs | 1.852 μs | 0.3805 |  13.04 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.90 μs | 0.105 μs | 0.070 μs | 0.4179 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  26.18 μs | 1.118 μs | 0.739 μs | 0.4937 |  14.72 KB |
| InvokeSync_ServiceError                           |  59.02 μs | 0.488 μs | 0.323 μs | 1.4098 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 256.60 μs | 2.595 μs | 1.544 μs | 3.6765 | 108.75 KB |
| EndpointRules_InvokeSync_JsonPost                 |  13.47 μs | 0.082 μs | 0.049 μs | 0.3785 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  24.00 μs | 1.669 μs | 1.104 μs | 0.4549 |  13.53 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  14.02 μs | 0.036 μs | 0.019 μs | 0.3945 |  11.17 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  24.57 μs | 1.420 μs | 0.939 μs | 0.4671 |   13.7 KB |
