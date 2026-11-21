```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.88 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.34 μs |  0.105 μs |  0.069 μs | 0.3448 |  10.51 KB |
| InvokeAsync_JsonPost              |  14.13 μs |  0.038 μs |  0.023 μs | 0.3952 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  18.89 μs |  0.506 μs |  0.335 μs | 0.3756 |   11.9 KB |
| InvokeSync_ServiceError           |  50.85 μs |  0.369 μs |  0.219 μs | 1.4159 |   44.3 KB |
| InvokeAsync_ServiceError_Yielding | 236.51 μs | 22.668 μs | 14.994 μs | 3.5714 | 108.57 KB |
