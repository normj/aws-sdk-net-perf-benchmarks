```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.18 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.05 μs | 0.113 μs | 0.075 μs | 0.3658 |  10.51 KB |
| InvokeAsync_JsonPost              |  15.22 μs | 0.066 μs | 0.034 μs | 0.3684 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  21.92 μs | 3.205 μs | 2.120 μs | 0.4269 |  13.04 KB |
| InvokeSync_ServiceError           |  56.84 μs | 0.379 μs | 0.251 μs | 1.6026 |  44.53 KB |
| InvokeAsync_ServiceError_Yielding | 252.76 μs | 3.270 μs | 1.946 μs | 2.9762 | 108.71 KB |
