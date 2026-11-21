```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.88 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   821.6 ns | 26.12 ns | 17.27 ns | 0.0586 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   906.4 ns | 21.57 ns | 14.27 ns | 0.0606 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,424.9 ns | 76.18 ns | 50.39 ns | 0.0650 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,386.1 ns | 73.57 ns | 43.78 ns | 0.0657 |   2.05 KB |
