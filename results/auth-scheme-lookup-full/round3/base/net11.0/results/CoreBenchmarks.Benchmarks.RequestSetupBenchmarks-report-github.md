```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev  | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|--------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   886.6 ns | 11.40 ns | 7.54 ns | 0.0627 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   927.3 ns | 10.18 ns | 6.06 ns | 0.0628 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,345.0 ns |  8.84 ns | 5.26 ns | 0.0670 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,403.4 ns | 14.89 ns | 7.79 ns | 0.0764 |   2.18 KB |
