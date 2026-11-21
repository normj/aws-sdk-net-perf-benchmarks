```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,172.5 ns | 28.73 ns | 17.10 ns | 0.0642 |   1.78 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   944.7 ns | 17.36 ns | 11.48 ns | 0.0598 |    1.7 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,009.4 ns | 31.89 ns | 21.09 ns | 0.0637 |   1.77 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,461.3 ns | 22.89 ns | 15.14 ns | 0.0690 |   1.98 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,571.6 ns | 13.28 ns |  8.78 ns | 0.0716 |   2.13 KB |
