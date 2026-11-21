```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,046.5 ns |  90.36 ns |  59.77 ns | 0.0598 |    1704 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   945.2 ns | 100.59 ns |  66.54 ns | 0.0573 |    1640 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   965.6 ns |  28.35 ns |  16.87 ns | 0.0576 |    1712 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,363.4 ns |  60.95 ns |  40.32 ns | 0.0677 |    1936 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,472.7 ns |   8.38 ns |   4.99 ns | 0.0690 |    2080 B |
| DefaultChain_ResolveIdentity                    | 1,248.7 ns |  21.34 ns |  11.16 ns | 0.0099 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,968.2 ns | 225.16 ns | 148.93 ns | 0.0076 |     368 B |
| UserAgentDetails_Build                          |   134.7 ns |  10.93 ns |   6.50 ns | 0.0069 |     208 B |
