```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |   968.88 ns |  9.466 ns |  6.261 ns | 0.0581 |    1704 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   827.14 ns |  8.677 ns |  5.739 ns | 0.0559 |    1640 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   859.09 ns | 13.965 ns |  9.237 ns | 0.0589 |    1712 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,354.17 ns | 22.639 ns | 11.841 ns | 0.0658 |    1936 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,418.10 ns | 20.801 ns | 13.758 ns | 0.0690 |    2080 B |
| DefaultChain_ResolveIdentity                    | 1,214.84 ns |  4.919 ns |  3.253 ns | 0.0097 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,204.89 ns | 14.299 ns |  9.458 ns | 0.0096 |     368 B |
| UserAgentDetails_Build                          |    75.33 ns |  0.182 ns |  0.108 ns | 0.0072 |     208 B |
