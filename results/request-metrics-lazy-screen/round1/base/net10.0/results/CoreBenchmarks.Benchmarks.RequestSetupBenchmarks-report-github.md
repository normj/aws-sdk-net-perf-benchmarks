```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1.255 μs | 0.0143 μs | 0.0037 μs | 0.0663 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.035 μs | 0.0186 μs | 0.0048 μs | 0.0621 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.089 μs | 0.0445 μs | 0.0159 μs | 0.0646 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.539 μs | 0.0683 μs | 0.0244 μs | 0.0702 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.716 μs | 0.3109 μs | 0.1109 μs | 0.0723 |   2.19 KB |
