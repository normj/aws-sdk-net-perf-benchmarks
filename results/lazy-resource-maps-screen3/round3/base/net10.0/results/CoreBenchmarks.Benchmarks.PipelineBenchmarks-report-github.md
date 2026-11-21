```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                  | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| InvokeSync_JsonPost                     | 13.70 μs | 0.574 μs | 0.149 μs | 0.3336 |  10.51 KB |
| InvokeSync_JsonPost_ManyResponseHeaders | 15.63 μs | 0.426 μs | 0.152 μs | 0.4366 |  12.19 KB |
