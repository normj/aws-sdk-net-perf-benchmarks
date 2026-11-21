```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.71 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.59 μs |  0.293 μs |  0.194 μs | 0.3307 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.58 μs |  0.134 μs |  0.070 μs | 0.3717 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  24.76 μs |  1.910 μs |  1.137 μs | 0.3834 |  13.04 KB |
| InvokeSync_ServiceError           |  58.24 μs |  0.789 μs |  0.522 μs | 1.3889 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding | 273.14 μs | 23.374 μs | 15.460 μs | 3.2328 | 108.47 KB |
