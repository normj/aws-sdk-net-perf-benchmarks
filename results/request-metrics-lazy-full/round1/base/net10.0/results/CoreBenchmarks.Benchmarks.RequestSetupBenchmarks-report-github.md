```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1.278 μs | 0.0226 μs | 0.0149 μs | 0.0615 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.036 μs | 0.0137 μs | 0.0091 μs | 0.0637 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.081 μs | 0.0246 μs | 0.0146 μs | 0.0642 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.530 μs | 0.0271 μs | 0.0142 μs | 0.0730 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.586 μs | 0.0462 μs | 0.0275 μs | 0.0746 |   2.19 KB |
