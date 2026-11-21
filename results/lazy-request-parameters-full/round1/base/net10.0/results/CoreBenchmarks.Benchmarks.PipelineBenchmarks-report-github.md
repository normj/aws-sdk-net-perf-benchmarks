```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.15 μs | 0.095 μs | 0.057 μs | 0.3664 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.62 μs | 0.230 μs | 0.152 μs | 0.3709 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  22.35 μs | 1.886 μs | 1.247 μs | 0.4229 |  13.04 KB |
| InvokeSync_ServiceError           |  57.08 μs | 0.208 μs | 0.124 μs | 1.5967 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding | 251.42 μs | 2.524 μs | 1.502 μs | 3.0242 | 108.46 KB |
