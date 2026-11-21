```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.88 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,108.4 ns |   9.21 ns |   6.09 ns | 0.0622 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    857.2 ns |   2.25 ns |   1.18 ns | 0.0616 |   1.75 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    894.6 ns |   3.01 ns |   1.79 ns | 0.0643 |   1.82 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,384.1 ns |   7.20 ns |   3.77 ns | 0.0666 |   2.04 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,405.0 ns |  16.65 ns |  11.01 ns | 0.0766 |   2.18 KB |
| Telemetry_InvokeSync                            | 17,716.4 ns | 473.27 ns | 313.04 ns | 0.4861 |  14.89 KB |
| Telemetry_InvokeAsync                           | 20,313.2 ns | 461.76 ns | 305.42 ns | 0.5704 |  16.15 KB |
