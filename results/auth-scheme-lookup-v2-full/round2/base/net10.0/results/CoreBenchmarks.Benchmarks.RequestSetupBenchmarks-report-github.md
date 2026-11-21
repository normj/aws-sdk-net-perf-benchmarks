```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      | 1.016 μs | 0.0245 μs | 0.0146 μs | 0.0612 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1.443 μs | 0.3450 μs | 0.2282 μs | 0.0644 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2.484 μs | 0.1070 μs | 0.0560 μs | 0.0735 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2.625 μs | 0.1574 μs | 0.1041 μs | 0.0755 |   2.19 KB |
