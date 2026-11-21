```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.016 μs | 0.0247 μs | 0.0147 μs | 0.0603 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.137 μs | 0.0744 μs | 0.0492 μs | 0.0644 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.397 μs | 0.0086 μs | 0.0051 μs | 0.0670 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.492 μs | 0.0077 μs | 0.0051 μs | 0.0699 |   2.19 KB |
