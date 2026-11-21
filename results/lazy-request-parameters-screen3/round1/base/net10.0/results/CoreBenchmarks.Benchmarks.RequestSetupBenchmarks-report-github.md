```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1.318 μs | 0.0699 μs | 0.0249 μs | 0.0661 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.056 μs | 0.0172 μs | 0.0061 μs | 0.0614 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.095 μs | 0.0711 μs | 0.0185 μs | 0.0657 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.556 μs | 0.1103 μs | 0.0393 μs | 0.0697 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.582 μs | 0.0567 μs | 0.0202 μs | 0.0727 |   2.19 KB |
