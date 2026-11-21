```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.99 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1.254 μs | 0.0208 μs | 0.0124 μs | 0.0598 |   1.78 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.424 μs | 0.3113 μs | 0.2059 μs | 0.0598 |    1.7 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.176 μs | 0.2449 μs | 0.1457 μs | 0.0629 |   1.77 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.592 μs | 0.3100 μs | 0.1845 μs | 0.0672 |   1.99 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 3.420 μs | 1.2643 μs | 0.8363 μs | 0.0749 |   2.13 KB |
