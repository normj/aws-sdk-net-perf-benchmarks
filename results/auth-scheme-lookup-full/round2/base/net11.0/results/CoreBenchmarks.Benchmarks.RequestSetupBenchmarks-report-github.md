```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.57 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   896.8 ns | 45.70 ns | 30.23 ns | 0.0604 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   903.6 ns |  5.76 ns |  3.81 ns | 0.0649 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,326.9 ns |  9.91 ns |  5.90 ns | 0.0653 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,467.1 ns | 30.80 ns | 18.33 ns | 0.0782 |   2.18 KB |
