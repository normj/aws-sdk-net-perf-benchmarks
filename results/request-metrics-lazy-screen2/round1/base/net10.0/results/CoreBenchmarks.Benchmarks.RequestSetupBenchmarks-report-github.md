```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,239.1 ns | 40.86 ns | 10.61 ns | 0.0641 |   1.84 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   982.6 ns | 10.38 ns |  3.70 ns | 0.0627 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,053.5 ns |  7.19 ns |  2.56 ns | 0.0635 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,341.7 ns | 48.20 ns | 12.52 ns | 0.0655 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,512.4 ns | 86.33 ns | 30.79 ns | 0.0697 |   2.19 KB |
