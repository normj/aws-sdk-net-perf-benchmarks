```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.98 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            |   979.41 ns | 12.388 ns |  7.372 ns | 0.0583 |    1704 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   835.82 ns |  4.105 ns |  2.443 ns | 0.0558 |    1640 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   872.22 ns |  5.572 ns |  2.914 ns | 0.0585 |    1712 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,357.46 ns | 14.411 ns |  8.576 ns | 0.0660 |    1936 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,470.53 ns | 13.208 ns |  7.860 ns | 0.0698 |    2080 B |
| DefaultChain_ResolveIdentity                    | 1,230.35 ns |  8.623 ns |  5.704 ns | 0.0098 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,213.70 ns | 15.823 ns | 10.466 ns | 0.0096 |     368 B |
| UserAgentDetails_Build                          |    74.02 ns |  0.112 ns |  0.067 ns | 0.0071 |     208 B |
