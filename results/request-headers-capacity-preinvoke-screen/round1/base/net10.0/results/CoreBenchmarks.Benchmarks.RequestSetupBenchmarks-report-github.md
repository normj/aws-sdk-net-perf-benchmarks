```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1.284 μs | 0.0470 μs | 0.0122 μs | 0.0616 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.021 μs | 0.0481 μs | 0.0171 μs | 0.0608 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.065 μs | 0.0551 μs | 0.0143 μs | 0.0629 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.462 μs | 0.0101 μs | 0.0036 μs | 0.0688 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.641 μs | 0.0508 μs | 0.0181 μs | 0.0711 |   2.19 KB |
