```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.008 μs | 0.0588 μs | 0.0350 μs | 0.0551 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.010 μs | 0.0583 μs | 0.0386 μs | 0.0590 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.524 μs | 0.0136 μs | 0.0090 μs | 0.0607 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.399 μs | 0.0064 μs | 0.0033 μs | 0.0674 |   2.05 KB |
