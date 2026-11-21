```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.44 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,166.1 ns |  76.39 ns |  50.53 ns | 0.0589 |   1.67 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    878.7 ns |  71.24 ns |  47.12 ns | 0.0552 |   1.59 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    880.4 ns |   5.78 ns |   3.82 ns | 0.0592 |   1.66 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,469.7 ns |  32.22 ns |  21.31 ns | 0.0588 |   1.88 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,487.8 ns |  39.56 ns |  26.17 ns | 0.0704 |   2.02 KB |
| Telemetry_InvokeSync                            | 18,080.4 ns | 401.28 ns | 265.43 ns | 0.5105 |  14.67 KB |
| Telemetry_InvokeAsync                           | 20,297.6 ns | 485.84 ns | 321.36 ns | 0.5645 |  15.93 KB |
