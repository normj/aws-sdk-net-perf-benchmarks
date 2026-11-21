```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.52 μs |  0.284 μs |  0.188 μs | 0.3580 |  10.51 KB |
| InvokeAsync_JsonPost              |  14.66 μs |  0.316 μs |  0.209 μs | 0.4058 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  24.09 μs |  1.522 μs |  0.796 μs | 0.4244 |  12.05 KB |
| InvokeSync_ServiceError           | 101.96 μs | 23.501 μs | 13.985 μs | 1.4881 |  48.34 KB |
| InvokeAsync_ServiceError_Yielding | 468.91 μs | 77.635 μs | 46.199 μs | 3.3784 | 108.13 KB |
