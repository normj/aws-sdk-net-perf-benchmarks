```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.007 μs | 0.0211 μs | 0.0055 μs | 0.0635 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.041 μs | 0.0306 μs | 0.0079 μs | 0.0622 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.644 μs | 0.2569 μs | 0.0916 μs | 0.0711 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.526 μs | 0.0318 μs | 0.0114 μs | 0.0702 |   2.19 KB |
