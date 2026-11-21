```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.32 μs | 0.088 μs | 0.058 μs | 0.3720 |  10.29 KB |
| InvokeAsync_JsonPost              |  15.53 μs | 0.092 μs | 0.055 μs | 0.3720 |  11.55 KB |
| InvokeAsync_JsonPost_Yielding     |  22.05 μs | 2.678 μs | 1.772 μs | 0.4287 |  12.82 KB |
| InvokeSync_ServiceError           |  56.54 μs | 0.219 μs | 0.115 μs | 1.5794 |  44.02 KB |
| InvokeAsync_ServiceError_Yielding | 246.70 μs | 3.177 μs | 1.890 μs | 3.9063 | 108.28 KB |
