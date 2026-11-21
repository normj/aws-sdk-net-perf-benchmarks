```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,108.7 ns |   9.61 ns |   5.72 ns | 0.0574 |   1.67 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    864.1 ns |   4.18 ns |   2.49 ns | 0.0552 |   1.59 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    883.9 ns |  10.38 ns |   6.86 ns | 0.0568 |   1.66 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,369.8 ns |   3.04 ns |   1.59 ns | 0.0665 |   1.88 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,356.4 ns |  10.88 ns |   7.19 ns | 0.0658 |   2.02 KB |
| Telemetry_InvokeSync                            | 17,635.8 ns |  92.31 ns |  61.06 ns | 0.4916 |  14.67 KB |
| Telemetry_InvokeAsync                           | 19,820.0 ns | 154.27 ns | 102.04 ns | 0.5524 |  15.93 KB |
