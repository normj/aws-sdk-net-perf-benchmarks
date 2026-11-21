```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.96 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.120 μs | 0.0194 μs | 0.0101 μs | 0.0604 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.140 μs | 0.0356 μs | 0.0235 μs | 0.0636 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.971 μs | 0.7745 μs | 0.4609 μs | 0.0704 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 3.776 μs | 1.4299 μs | 0.9458 μs | 0.0751 |   2.19 KB |
