```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   971.2 ns | 15.02 ns |  9.94 ns | 0.0567 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,052.1 ns | 10.16 ns |  6.72 ns | 0.0588 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,472.0 ns | 22.15 ns | 13.18 ns | 0.0594 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,497.3 ns | 16.32 ns |  9.71 ns | 0.0697 |   2.05 KB |
