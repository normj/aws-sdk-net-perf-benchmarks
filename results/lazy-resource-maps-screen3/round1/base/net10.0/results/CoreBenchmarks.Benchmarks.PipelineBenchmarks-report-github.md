```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.22 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                  | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                     | 13.72 μs | 0.254 μs | 0.091 μs | 0.3281 |  10.51 KB |
| InvokeSync_JsonPost_ManyResponseHeaders | 16.94 μs | 3.913 μs | 1.396 μs | 0.4415 |  12.19 KB |
