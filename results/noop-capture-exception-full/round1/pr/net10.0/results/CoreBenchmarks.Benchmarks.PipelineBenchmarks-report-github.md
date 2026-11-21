```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.75 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.45 μs | 0.112 μs | 0.067 μs | 0.3287 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.77 μs | 0.093 μs | 0.055 μs | 0.3792 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  23.95 μs | 2.775 μs | 1.836 μs | 0.4589 |  13.04 KB |
| InvokeSync_ServiceError           |  39.30 μs | 0.252 μs | 0.167 μs | 0.4688 |  15.14 KB |
| InvokeAsync_ServiceError_Yielding | 121.54 μs | 0.489 μs | 0.291 μs | 1.4423 |   44.6 KB |
