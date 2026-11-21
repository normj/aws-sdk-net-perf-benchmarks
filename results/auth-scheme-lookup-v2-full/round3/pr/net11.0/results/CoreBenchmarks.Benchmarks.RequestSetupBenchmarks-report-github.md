```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   859.8 ns | 23.92 ns | 15.82 ns | 0.0565 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   920.1 ns | 29.07 ns | 19.23 ns | 0.0584 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,451.6 ns | 50.07 ns | 33.12 ns | 0.0681 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,542.1 ns | 61.50 ns | 40.68 ns | 0.0697 |   2.05 KB |
