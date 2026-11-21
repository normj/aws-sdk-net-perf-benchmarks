```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.21 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.07 μs | 0.072 μs | 0.048 μs | 0.3363 |  10.51 KB |
| InvokeAsync_JsonPost              |  14.03 μs | 0.063 μs | 0.037 μs | 0.3945 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  19.08 μs | 0.348 μs | 0.182 μs | 0.3747 |  11.92 KB |
| InvokeSync_ServiceError           |  55.13 μs | 0.146 μs | 0.076 μs | 1.7606 |  48.61 KB |
| InvokeAsync_ServiceError_Yielding | 220.68 μs | 1.312 μs | 0.781 μs | 3.5211 | 108.81 KB |
