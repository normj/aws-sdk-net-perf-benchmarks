```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.29 μs | 0.088 μs | 0.052 μs | 0.3448 |  10.51 KB |
| InvokeAsync_JsonPost              |  13.92 μs | 0.083 μs | 0.043 μs | 0.3899 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  20.70 μs | 0.126 μs | 0.075 μs | 0.4161 |  12.24 KB |
| InvokeSync_ServiceError           |  34.08 μs | 0.083 μs | 0.043 μs | 0.5470 |  15.14 KB |
| InvokeAsync_ServiceError_Yielding | 101.70 μs | 1.947 μs | 1.159 μs | 1.6026 |  44.67 KB |
