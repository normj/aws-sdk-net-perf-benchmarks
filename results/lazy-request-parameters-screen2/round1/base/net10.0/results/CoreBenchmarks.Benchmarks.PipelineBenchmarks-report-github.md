```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean      | Error     | StdDev    | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|----------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.97 μs |  0.359 μs |  0.128 μs | 0.3595 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.76 μs |  0.290 μs |  0.103 μs | 0.3761 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  32.71 μs |  3.210 μs |  1.145 μs | 0.4019 |  13.04 KB |
| InvokeSync_ServiceError           |  61.00 μs |  4.573 μs |  1.631 μs | 1.4468 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding | 326.37 μs | 72.344 μs | 25.799 μs | 3.5377 | 108.49 KB |
