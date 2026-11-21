```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.68 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean        | Error       | StdDev      | Gen0   | Allocated |
|------------------------------------------------ |------------:|------------:|------------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,278.5 ns |    51.75 ns |    18.45 ns | 0.0605 |   1.67 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    995.4 ns |     4.00 ns |     1.43 ns | 0.0555 |   1.59 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |  1,019.4 ns |    14.42 ns |     5.14 ns | 0.0572 |   1.66 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,536.9 ns |   146.11 ns |    52.10 ns | 0.0606 |   1.88 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,757.0 ns |   293.99 ns |    76.35 ns | 0.0661 |   2.02 KB |
| Telemetry_InvokeSync                            | 20,827.5 ns | 4,042.77 ns | 1,441.69 ns | 0.5309 |  14.67 KB |
| Telemetry_InvokeAsync                           | 22,328.9 ns |   803.29 ns |   286.46 ns | 0.5327 |  16.01 KB |
