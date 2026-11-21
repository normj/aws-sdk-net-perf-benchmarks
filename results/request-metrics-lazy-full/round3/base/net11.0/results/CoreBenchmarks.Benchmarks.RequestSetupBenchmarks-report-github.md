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
| Marshaller_PreInvoke                            | 1,109.0 ns | 54.66 ns | 36.15 ns | 0.0637 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   864.0 ns |  7.03 ns |  4.18 ns | 0.0620 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   906.3 ns |  8.41 ns |  5.57 ns | 0.0648 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,443.8 ns | 54.19 ns | 35.84 ns | 0.0659 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,471.8 ns | 15.52 ns | 10.27 ns | 0.0789 |   2.18 KB |
