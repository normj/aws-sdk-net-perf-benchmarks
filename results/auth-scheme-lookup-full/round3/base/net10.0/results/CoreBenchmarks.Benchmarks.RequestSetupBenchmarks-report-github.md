```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   999.4 ns |  2.80 ns |  1.85 ns | 0.0632 |   1.76 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,032.0 ns | 10.22 ns |  6.08 ns | 0.0660 |   1.83 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,368.0 ns | 34.64 ns | 20.61 ns | 0.0657 |   2.05 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,471.4 ns | 13.33 ns |  8.82 ns | 0.0697 |   2.19 KB |
