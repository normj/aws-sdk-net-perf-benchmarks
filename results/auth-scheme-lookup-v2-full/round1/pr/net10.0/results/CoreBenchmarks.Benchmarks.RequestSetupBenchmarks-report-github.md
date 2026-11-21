```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   978.5 ns |  17.98 ns |  10.70 ns | 0.0583 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,034.7 ns |  26.57 ns |  15.81 ns | 0.0609 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,581.5 ns |  97.90 ns |  64.75 ns | 0.0680 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,630.3 ns | 225.54 ns | 149.18 ns | 0.0697 |   2.05 KB |
