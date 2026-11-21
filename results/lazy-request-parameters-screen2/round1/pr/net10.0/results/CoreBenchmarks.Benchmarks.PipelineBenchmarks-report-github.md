```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.68 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  14.09 μs |  1.263 μs | 0.450 μs | 0.3222 |  10.29 KB |
| InvokeAsync_JsonPost              |  15.39 μs |  0.348 μs | 0.090 μs | 0.3691 |  11.55 KB |
| InvokeAsync_JsonPost_Yielding     |  24.36 μs |  4.194 μs | 1.496 μs | 0.3759 |  12.82 KB |
| InvokeSync_ServiceError           |  58.07 μs |  1.042 μs | 0.271 μs | 1.3993 |  44.02 KB |
| InvokeAsync_ServiceError_Yielding | 269.43 μs | 27.032 μs | 9.640 μs | 3.2328 | 108.25 KB |
