```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.1 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.056 μs | 0.0228 μs | 0.0151 μs | 0.0596 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.092 μs | 0.0216 μs | 0.0143 μs | 0.0650 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.494 μs | 0.0596 μs | 0.0394 μs | 0.0673 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.530 μs | 0.0468 μs | 0.0309 μs | 0.0705 |   2.19 KB |
