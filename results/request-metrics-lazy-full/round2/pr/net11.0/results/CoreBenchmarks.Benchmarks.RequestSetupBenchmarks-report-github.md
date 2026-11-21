```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.25 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,065.2 ns | 10.53 ns |  6.96 ns | 0.0631 |   1.78 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   839.1 ns |  7.43 ns |  4.42 ns | 0.0607 |    1.7 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   875.7 ns |  3.62 ns |  2.39 ns | 0.0630 |   1.77 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,374.1 ns | 10.84 ns |  6.45 ns | 0.0664 |   1.98 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,419.6 ns | 19.03 ns | 11.33 ns | 0.0677 |   2.13 KB |
