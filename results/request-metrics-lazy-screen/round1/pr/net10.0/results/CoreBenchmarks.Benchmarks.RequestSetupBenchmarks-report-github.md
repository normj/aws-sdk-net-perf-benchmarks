```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.08 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1.367 μs | 0.0509 μs | 0.0182 μs | 0.0623 |   1.78 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.072 μs | 0.0755 μs | 0.0269 μs | 0.0578 |    1.7 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.093 μs | 0.0555 μs | 0.0198 μs | 0.0641 |   1.77 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.687 μs | 0.3290 μs | 0.1173 μs | 0.0716 |   1.99 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.578 μs | 0.1110 μs | 0.0288 μs | 0.0724 |   2.13 KB |
