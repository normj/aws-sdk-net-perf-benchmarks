```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   932.8 ns |  7.16 ns |  4.74 ns | 0.0557 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   981.7 ns |  4.19 ns |  2.50 ns | 0.0589 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,353.7 ns | 33.85 ns | 22.39 ns | 0.0652 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,374.3 ns |  7.79 ns |  4.64 ns | 0.0664 |   2.05 KB |
