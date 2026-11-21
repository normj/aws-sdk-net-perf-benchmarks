```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.15 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.78 μs |  0.727 μs | 0.259 μs | 0.3415 |  10.51 KB |
| InvokeAsync_JsonPost              |  16.24 μs |  1.000 μs | 0.357 μs | 0.3827 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  27.66 μs |  3.202 μs | 1.142 μs | 0.4266 |  13.04 KB |
| InvokeSync_ServiceError           |  59.46 μs |  1.962 μs | 0.510 μs | 1.4648 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding | 284.03 μs | 16.540 μs | 5.898 μs | 3.4091 | 108.48 KB |
