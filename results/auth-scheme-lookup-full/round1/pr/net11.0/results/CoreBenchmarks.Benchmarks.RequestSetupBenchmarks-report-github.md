```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   845.1 ns | 17.20 ns | 11.37 ns | 0.0578 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   896.7 ns |  9.90 ns |  6.55 ns | 0.0576 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,350.6 ns | 10.67 ns |  6.35 ns | 0.0656 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,454.3 ns | 14.79 ns |  9.78 ns | 0.0683 |   2.05 KB |
