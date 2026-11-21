```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.99 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,066.9 ns | 17.02 ns | 11.26 ns | 0.0637 |    1880 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   849.8 ns |  4.62 ns |  3.06 ns | 0.0610 |    1792 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   872.3 ns |  7.20 ns |  4.28 ns | 0.0629 |    1864 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,319.7 ns | 21.72 ns | 12.92 ns | 0.0656 |    2088 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,420.1 ns | 19.85 ns | 11.81 ns | 0.0774 |    2232 B |
| DefaultChain_ResolveIdentity                    | 1,211.7 ns |  3.74 ns |  2.23 ns | 0.0097 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,199.0 ns | 14.15 ns |  9.36 ns | 0.0095 |     368 B |
| UserAgentDetails_Build                          |   217.4 ns |  0.86 ns |  0.51 ns | 0.0201 |     576 B |
