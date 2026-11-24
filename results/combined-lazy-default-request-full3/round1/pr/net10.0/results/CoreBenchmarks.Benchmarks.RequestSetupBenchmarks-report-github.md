```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.02 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,173.9 ns |   2.20 ns |   1.45 ns | 0.0519 |   1.44 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    930.2 ns |   2.36 ns |   1.41 ns | 0.0483 |   1.36 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    946.4 ns |   1.59 ns |   0.95 ns | 0.0491 |   1.43 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,434.1 ns |  15.50 ns |  10.25 ns | 0.0578 |   1.65 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,472.9 ns |  13.55 ns |   8.06 ns | 0.0591 |   1.79 KB |
| Telemetry_InvokeSync                            | 18,750.6 ns | 173.18 ns | 114.55 ns | 0.4502 |  14.44 KB |
| Telemetry_InvokeAsync                           | 21,478.5 ns |  72.69 ns |  43.26 ns | 0.5144 |  15.77 KB |
| NewRequest_InvokeSync                           | 14,161.6 ns |  53.88 ns |  32.06 ns | 0.3378 |  10.27 KB |
| NewRequest_InvokeAsync                          | 16,805.3 ns |  56.57 ns |  33.67 ns | 0.4032 |  11.61 KB |
| RefreshingCredentials_InvokeAsync               | 17,615.4 ns |  38.63 ns |  22.99 ns | 0.4233 |   11.9 KB |
