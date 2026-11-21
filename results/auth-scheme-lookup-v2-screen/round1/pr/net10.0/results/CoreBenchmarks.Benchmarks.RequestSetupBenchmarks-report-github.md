```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.64 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.002 μs | 0.0359 μs | 0.0093 μs | 0.0559 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.038 μs | 0.0212 μs | 0.0055 μs | 0.0590 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.375 μs | 0.0308 μs | 0.0110 μs | 0.0666 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.380 μs | 0.0100 μs | 0.0026 μs | 0.0666 |   2.05 KB |
