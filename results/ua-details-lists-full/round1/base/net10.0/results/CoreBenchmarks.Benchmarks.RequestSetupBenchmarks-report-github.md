```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.97 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,293.0 ns | 21.02 ns | 11.00 ns | 0.0665 |    1880 B |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1,050.2 ns | 18.13 ns | 11.99 ns | 0.0621 |    1800 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,047.9 ns |  9.92 ns |  5.91 ns | 0.0626 |    1872 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,419.3 ns |  3.54 ns |  2.34 ns | 0.0677 |    2096 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,550.2 ns | 13.30 ns |  7.91 ns | 0.0712 |    2240 B |
| DefaultChain_ResolveIdentity                    | 1,182.4 ns |  2.26 ns |  1.35 ns | 0.0094 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,175.5 ns | 16.09 ns |  9.57 ns | 0.0094 |     368 B |
| UserAgentDetails_Build                          |   217.3 ns |  0.77 ns |  0.46 ns | 0.0200 |     576 B |
