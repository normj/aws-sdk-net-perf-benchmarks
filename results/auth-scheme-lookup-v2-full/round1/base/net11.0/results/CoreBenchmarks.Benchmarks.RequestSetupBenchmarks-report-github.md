```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   885.4 ns |  41.03 ns |  27.14 ns | 0.0622 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,358.0 ns | 315.81 ns | 208.89 ns | 0.0622 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 3,307.0 ns | 868.04 ns | 574.16 ns | 0.0735 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,467.0 ns |  34.27 ns |  22.67 ns | 0.0776 |   2.18 KB |
