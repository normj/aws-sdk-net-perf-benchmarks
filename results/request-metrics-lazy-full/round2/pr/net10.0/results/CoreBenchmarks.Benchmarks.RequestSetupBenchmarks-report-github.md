```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,220.6 ns | 13.45 ns |  8.00 ns | 0.0628 |   1.78 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   975.4 ns | 13.85 ns |  8.24 ns | 0.0581 |    1.7 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,020.3 ns |  3.72 ns |  2.46 ns | 0.0612 |   1.77 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,440.2 ns | 18.05 ns | 11.94 ns | 0.0692 |   1.99 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,522.9 ns |  5.28 ns |  2.76 ns | 0.0707 |   2.13 KB |
