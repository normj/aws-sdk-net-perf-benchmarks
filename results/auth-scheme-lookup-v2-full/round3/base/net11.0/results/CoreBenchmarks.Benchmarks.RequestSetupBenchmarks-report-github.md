```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   923.0 ns | 23.16 ns | 15.32 ns | 0.0622 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   913.3 ns |  7.61 ns |  5.03 ns | 0.0659 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,438.1 ns | 17.93 ns | 11.86 ns | 0.0679 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,573.4 ns | 44.00 ns | 29.10 ns | 0.0720 |   2.18 KB |
