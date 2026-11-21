```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,113.4 ns |  19.54 ns |  12.93 ns | 0.0635 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   893.1 ns |  21.52 ns |  14.23 ns | 0.0602 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,267.5 ns | 381.37 ns | 252.25 ns | 0.0642 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             | 4,351.5 ns | 958.25 ns | 570.24 ns | 0.0684 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 3,939.4 ns | 542.38 ns | 358.75 ns | 0.0766 |   2.18 KB |
