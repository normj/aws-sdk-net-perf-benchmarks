```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.83 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,230.5 ns |   5.48 ns |  3.26 ns | 0.0596 |   1.67 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    969.6 ns |   1.33 ns |  0.70 ns | 0.0543 |   1.59 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1,023.9 ns |   2.68 ns |  1.59 ns | 0.0572 |   1.66 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,494.1 ns |  10.89 ns |  6.48 ns | 0.0598 |   1.88 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,656.8 ns |  88.51 ns | 58.54 ns | 0.0732 |   2.02 KB |
| Telemetry_InvokeSync                            | 18,243.9 ns |  63.49 ns | 33.20 ns | 0.5105 |  14.67 KB |
| Telemetry_InvokeAsync                           | 21,228.4 ns | 102.81 ns | 61.18 ns | 0.5095 |  16.01 KB |
