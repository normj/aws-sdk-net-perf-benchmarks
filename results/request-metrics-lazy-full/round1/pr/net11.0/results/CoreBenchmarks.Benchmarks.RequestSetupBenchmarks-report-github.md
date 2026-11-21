```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,062.3 ns | 19.10 ns | 12.63 ns | 0.0645 |   1.78 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   842.1 ns |  4.65 ns |  2.76 ns | 0.0606 |    1.7 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   886.0 ns |  1.74 ns |  0.91 ns | 0.0638 |   1.77 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,328.4 ns | 11.42 ns |  7.55 ns | 0.0649 |   1.98 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,400.6 ns | 17.81 ns | 10.60 ns | 0.0679 |   2.13 KB |
