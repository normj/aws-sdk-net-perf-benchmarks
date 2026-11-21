```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.47 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                  | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                     | 13.50 μs | 0.571 μs | 0.148 μs | 0.3768 |  10.51 KB |
| InvokeSync_JsonPost_ManyResponseHeaders | 15.46 μs | 0.198 μs | 0.051 μs | 0.4298 |  12.19 KB |
