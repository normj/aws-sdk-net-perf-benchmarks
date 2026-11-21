```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,092.7 ns |  12.56 ns |   7.47 ns | 0.0622 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   881.7 ns |   3.19 ns |   1.90 ns | 0.0634 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   931.7 ns |  11.61 ns |   7.68 ns | 0.0627 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 3,089.1 ns | 782.74 ns | 517.73 ns | 0.0677 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 3,277.0 ns | 942.05 ns | 623.11 ns | 0.0696 |   2.18 KB |
