```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.94 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error       | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |-----------:|------------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   885.5 ns |    16.05 ns |  10.62 ns | 0.0633 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   914.0 ns |    11.55 ns |   6.87 ns | 0.0654 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 3,223.6 ns | 1,033.04 ns | 683.29 ns | 0.0678 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,475.0 ns |   186.11 ns |  97.34 ns | 0.0743 |   2.18 KB |
