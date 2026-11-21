```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev  | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|--------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   801.4 ns |  6.83 ns | 4.52 ns | 0.0575 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   850.7 ns |  7.51 ns | 4.47 ns | 0.0591 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,290.1 ns | 10.30 ns | 6.82 ns | 0.0640 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,370.5 ns |  6.14 ns | 3.21 ns | 0.0668 |   2.05 KB |
