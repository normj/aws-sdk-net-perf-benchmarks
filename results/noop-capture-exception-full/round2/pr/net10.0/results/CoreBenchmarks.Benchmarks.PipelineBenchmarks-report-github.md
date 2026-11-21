```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  13.73 μs |  0.098 μs | 0.065 μs | 0.3287 |  10.51 KB |
| InvokeAsync_JsonPost              |  16.07 μs |  0.080 μs | 0.042 μs | 0.3803 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  32.20 μs |  2.337 μs | 1.546 μs | 0.4456 |  13.04 KB |
| InvokeSync_ServiceError           |  40.29 μs |  0.112 μs | 0.066 μs | 0.4832 |  15.14 KB |
| InvokeAsync_ServiceError_Yielding | 150.95 μs | 10.841 μs | 7.171 μs | 1.1792 |   44.6 KB |
