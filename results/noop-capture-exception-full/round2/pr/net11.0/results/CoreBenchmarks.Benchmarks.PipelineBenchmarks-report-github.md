```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.22 μs |  0.044 μs | 0.026 μs | 0.3698 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.18 μs |  0.072 μs | 0.048 μs | 0.4260 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  23.75 μs |  0.451 μs | 0.268 μs | 0.3765 |  12.06 KB |
| InvokeSync_ServiceError           |  35.21 μs |  0.272 μs | 0.162 μs | 0.4195 |  15.14 KB |
| InvokeAsync_ServiceError_Yielding | 117.24 μs | 10.591 μs | 7.005 μs | 1.4423 |  44.67 KB |
