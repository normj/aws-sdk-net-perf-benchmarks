```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.61 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                            | Mean      | Error     | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|----------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  18.29 μs |  6.844 μs | 2.441 μs | 0.3425 |  10.29 KB |
| InvokeAsync_JsonPost              |  30.64 μs | 14.773 μs | 5.268 μs | 0.3685 |  11.55 KB |
| InvokeAsync_JsonPost_Yielding     |  35.14 μs |  8.686 μs | 3.097 μs | 0.3914 |  12.82 KB |
| InvokeSync_ServiceError           |  67.93 μs |  4.713 μs | 1.681 μs | 1.4970 |  44.02 KB |
| InvokeAsync_ServiceError_Yielding | 290.64 μs | 25.042 μs | 8.930 μs | 3.4722 | 108.27 KB |
