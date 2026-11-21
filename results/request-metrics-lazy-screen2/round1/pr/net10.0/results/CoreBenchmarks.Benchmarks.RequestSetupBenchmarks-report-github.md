```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,224.9 ns | 30.98 ns | 11.05 ns | 0.0631 |   1.78 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   980.1 ns | 20.62 ns |  5.35 ns | 0.0584 |    1.7 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,017.2 ns | 13.54 ns |  4.83 ns | 0.0607 |   1.77 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,407.1 ns | 27.07 ns |  7.03 ns | 0.0671 |   1.99 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,481.2 ns | 63.89 ns | 22.78 ns | 0.0687 |   2.13 KB |
