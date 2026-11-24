```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                               |  12.62 μs | 0.017 μs | 0.009 μs | 0.3508 |  10.51 KB |
| InvokeAsync_JsonPost                              |  14.81 μs | 0.095 μs | 0.063 μs | 0.4127 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding                     |  19.90 μs | 0.244 μs | 0.145 μs | 0.3971 |  11.95 KB |
| InvokeSync_JsonPost_ManyResponseHeaders           |  14.26 μs | 0.130 μs | 0.077 μs | 0.3985 |  12.19 KB |
| InvokeAsync_JsonPost_ManyResponseHeaders_Yielding |  22.15 μs | 0.400 μs | 0.238 μs | 0.4414 |  13.75 KB |
| InvokeSync_ServiceError                           |  53.82 μs | 0.392 μs | 0.259 μs | 1.4983 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding                 | 233.68 μs | 2.877 μs | 1.712 μs | 3.6765 | 108.82 KB |
| EndpointRules_InvokeSync_JsonPost                 |  12.94 μs | 0.120 μs | 0.071 μs | 0.3619 |     11 KB |
| EndpointRules_InvokeAsync_JsonPost_Yielding       |  21.38 μs | 2.512 μs | 1.661 μs | 0.3941 |  12.43 KB |
| EndpointDiscovery_InvokeSync_JsonPost             |  13.43 μs | 0.279 μs | 0.185 μs | 0.3698 |  11.16 KB |
| EndpointDiscovery_InvokeAsync_JsonPost_Yielding   |  21.79 μs | 0.667 μs | 0.397 μs | 0.4246 |  12.61 KB |
