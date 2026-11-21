```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1.277 μs | 0.0566 μs | 0.0202 μs | 0.0602 |   1.67 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.018 μs | 0.0266 μs | 0.0095 μs | 0.0568 |   1.59 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.037 μs | 0.0489 μs | 0.0174 μs | 0.0591 |   1.66 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.468 μs | 0.1831 μs | 0.0653 μs | 0.0586 |   1.88 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.482 μs | 0.0646 μs | 0.0168 μs | 0.0704 |   2.02 KB |
