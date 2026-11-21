```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   852.4 ns | 16.93 ns | 11.20 ns | 0.0603 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   919.4 ns | 23.96 ns | 12.53 ns | 0.0647 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,419.6 ns | 32.00 ns | 19.04 ns | 0.0675 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,440.0 ns | 21.82 ns | 11.41 ns | 0.0693 |   2.18 KB |
