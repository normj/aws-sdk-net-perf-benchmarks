```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            |  1,094.3 ns |  24.46 ns | 16.18 ns | 0.0600 |   1.67 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |    854.4 ns |   1.77 ns |  0.93 ns | 0.0546 |   1.59 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |    916.2 ns |  10.11 ns |  6.69 ns | 0.0588 |   1.66 KB |
| AuthResolver_PreInvoke_DefaultChain             |  2,460.7 ns |  20.06 ns | 13.27 ns | 0.0589 |   1.88 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        |  2,428.1 ns |   7.47 ns |  3.91 ns | 0.0678 |   2.02 KB |
| Telemetry_InvokeSync                            | 17,239.1 ns | 142.59 ns | 94.32 ns | 0.4888 |  14.67 KB |
| Telemetry_InvokeAsync                           | 19,995.9 ns | 135.89 ns | 89.88 ns | 0.5573 |  15.93 KB |
