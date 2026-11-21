```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,142.9 ns |   3.80 ns |  1.99 ns | 0.0643 |   1.78 KB |
| AuthResolver_PreInvoke_ExplicitCredentials      |   922.0 ns |   6.35 ns |  3.78 ns | 0.0589 |    1.7 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,065.2 ns |  17.91 ns | 11.84 ns | 0.0629 |   1.77 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,473.2 ns |  30.69 ns | 20.30 ns | 0.0685 |   1.99 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,645.3 ns | 119.74 ns | 71.26 ns | 0.0712 |   2.13 KB |
