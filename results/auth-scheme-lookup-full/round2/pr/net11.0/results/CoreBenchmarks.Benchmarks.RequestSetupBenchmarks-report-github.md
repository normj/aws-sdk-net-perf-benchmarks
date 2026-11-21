```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.41 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   799.8 ns |  3.59 ns |  2.37 ns | 0.0576 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   843.5 ns | 11.41 ns |  5.97 ns | 0.0607 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,330.5 ns | 22.73 ns | 15.03 ns | 0.0649 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,323.7 ns | 12.08 ns |  7.99 ns | 0.0739 |   2.05 KB |
