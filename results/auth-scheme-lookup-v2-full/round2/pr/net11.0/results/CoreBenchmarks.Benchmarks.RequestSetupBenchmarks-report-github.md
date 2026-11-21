```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   812.2 ns | 17.74 ns | 11.73 ns | 0.0576 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   875.5 ns | 14.43 ns |  9.54 ns | 0.0590 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,389.5 ns | 89.41 ns | 53.20 ns | 0.0654 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,459.7 ns | 44.93 ns | 26.74 ns | 0.0665 |   2.05 KB |
