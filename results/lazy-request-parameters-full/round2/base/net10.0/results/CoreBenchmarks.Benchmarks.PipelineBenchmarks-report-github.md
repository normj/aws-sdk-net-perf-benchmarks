```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.11 μs | 0.093 μs | 0.055 μs | 0.3683 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.41 μs | 0.158 μs | 0.094 μs | 0.3666 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  22.17 μs | 2.043 μs | 1.351 μs | 0.4234 |  13.04 KB |
| InvokeSync_ServiceError           |  58.97 μs | 2.252 μs | 1.340 μs | 1.4764 |  44.31 KB |
| InvokeAsync_ServiceError_Yielding | 249.07 μs | 2.446 μs | 1.618 μs | 2.9762 | 108.46 KB |
