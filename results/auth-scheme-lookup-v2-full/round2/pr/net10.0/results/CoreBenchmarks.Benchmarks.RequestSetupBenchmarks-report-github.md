```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.05 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev  | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|--------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   924.5 ns |  2.11 ns | 1.10 ns | 0.0555 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   979.4 ns |  7.44 ns | 4.43 ns | 0.0587 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,307.4 ns |  9.95 ns | 6.58 ns | 0.0645 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,398.4 ns | 11.40 ns | 6.78 ns | 0.0671 |   2.05 KB |
