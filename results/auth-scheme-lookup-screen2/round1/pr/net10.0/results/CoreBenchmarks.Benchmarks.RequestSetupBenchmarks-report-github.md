```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean       | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|---------:|-------:|----------:|
| AuthResolver_PreInvoke_ExplicitCredentials      |   924.3 ns |  10.48 ns |  2.72 ns | 0.0553 |   1.62 KB |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   970.6 ns |   1.54 ns |  0.55 ns | 0.0582 |   1.69 KB |
| AuthResolver_PreInvoke_DefaultChain             | 2,362.3 ns |  54.54 ns | 19.45 ns | 0.0656 |   1.91 KB |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,407.8 ns | 128.13 ns | 45.69 ns | 0.0654 |   2.05 KB |
