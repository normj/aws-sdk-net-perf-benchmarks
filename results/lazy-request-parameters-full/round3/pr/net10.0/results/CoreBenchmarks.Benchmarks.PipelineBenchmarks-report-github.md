```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.24 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.10 μs | 0.073 μs | 0.038 μs | 0.3692 |  10.29 KB |
| InvokeAsync_JsonPost              |  15.43 μs | 0.098 μs | 0.058 μs | 0.3720 |  11.55 KB |
| InvokeAsync_JsonPost_Yielding     |  21.60 μs | 1.217 μs | 0.637 μs | 0.4195 |  12.82 KB |
| InvokeSync_ServiceError           |  56.76 μs | 0.474 μs | 0.282 μs | 1.3686 |  44.02 KB |
| InvokeAsync_ServiceError_Yielding | 250.70 μs | 4.668 μs | 2.778 μs | 3.1250 | 108.24 KB |
