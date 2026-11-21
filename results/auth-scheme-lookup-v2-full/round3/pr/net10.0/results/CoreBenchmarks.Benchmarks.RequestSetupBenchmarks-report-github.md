```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.033 μs | 0.0046 μs | 0.0024 μs | 0.0582 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.097 μs | 0.0143 μs | 0.0095 μs | 0.0609 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.472 μs | 0.0180 μs | 0.0094 μs | 0.0596 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.525 μs | 0.0180 μs | 0.0107 μs | 0.0702 |   2.05 KB |
