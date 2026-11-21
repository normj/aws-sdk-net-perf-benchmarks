```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev  | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|--------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,231.3 ns | 10.75 ns | 7.11 ns | 0.0638 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   999.2 ns |  7.25 ns | 4.79 ns | 0.0599 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,032.1 ns |  2.98 ns | 1.97 ns | 0.0661 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,396.3 ns | 12.82 ns | 8.48 ns | 0.0671 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,464.8 ns |  7.05 ns | 4.66 ns | 0.0786 |   2.19 KB |
