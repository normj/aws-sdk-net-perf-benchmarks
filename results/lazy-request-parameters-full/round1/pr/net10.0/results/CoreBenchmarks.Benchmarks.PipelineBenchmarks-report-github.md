```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.83 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.05 μs | 0.055 μs | 0.036 μs | 0.3646 |  10.29 KB |
| InvokeAsync_JsonPost              |  14.79 μs | 0.068 μs | 0.045 μs | 0.4131 |  11.55 KB |
| InvokeAsync_JsonPost_Yielding     |  22.05 μs | 2.120 μs | 1.402 μs | 0.4484 |  12.82 KB |
| InvokeSync_ServiceError           |  58.25 μs | 0.662 μs | 0.438 μs | 1.3889 |  44.02 KB |
| InvokeAsync_ServiceError_Yielding | 250.48 μs | 2.591 μs | 1.355 μs | 2.9762 | 108.23 KB |
