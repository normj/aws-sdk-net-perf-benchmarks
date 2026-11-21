```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.60 μs |  0.335 μs |  0.222 μs | 0.3791 |  10.51 KB |
| InvokeAsync_JsonPost              |  16.35 μs |  1.601 μs |  1.059 μs | 0.3735 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  21.93 μs |  1.865 μs |  1.110 μs | 0.4596 |  13.04 KB |
| InvokeSync_ServiceError           |  57.87 μs |  1.292 μs |  0.769 μs | 1.6026 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding | 268.78 μs | 36.588 μs | 24.201 μs | 3.6765 | 108.75 KB |
