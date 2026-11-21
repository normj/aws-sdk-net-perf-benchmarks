```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                            | Mean      | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------- |----------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost               |  12.65 μs | 0.110 μs | 0.066 μs | 0.3560 |  10.51 KB |
| InvokeAsync_JsonPost              |  14.29 μs | 0.160 μs | 0.106 μs | 0.4047 |  11.77 KB |
| InvokeAsync_JsonPost_Yielding     |  20.66 μs | 1.404 μs | 0.929 μs | 0.4223 |  12.04 KB |
| InvokeSync_ServiceError           |  53.54 μs | 0.345 μs | 0.228 μs | 1.7065 |  48.34 KB |
| InvokeAsync_ServiceError_Yielding | 222.12 μs | 1.579 μs | 0.940 μs | 3.5211 | 108.57 KB |
