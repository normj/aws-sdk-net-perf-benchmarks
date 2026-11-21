```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,313.8 ns |  5.30 ns |  3.51 ns | 0.0577 |   1.67 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    999.7 ns |  1.77 ns |  1.05 ns | 0.0563 |   1.59 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    995.3 ns |  8.85 ns |  5.85 ns | 0.0592 |   1.66 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,527.6 ns | 14.24 ns |  8.48 ns | 0.0607 |   1.88 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,606.6 ns |  9.04 ns |  5.98 ns | 0.0727 |   2.02 KB |
| Telemetry_InvokeSync                            | 18,960.2 ns | 59.59 ns | 31.17 ns | 0.5290 |  14.67 KB |
| Telemetry_InvokeAsync                           | 21,848.0 ns | 99.73 ns | 59.35 ns | 0.5230 |  16.01 KB |
