```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev  | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|--------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,237.2 ns |  4.60 ns | 3.04 ns | 0.0640 |    1880 B |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1,003.3 ns |  1.56 ns | 0.93 ns | 0.0635 |    1800 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,056.5 ns |  3.27 ns | 1.71 ns | 0.0632 |    1872 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,364.8 ns | 11.68 ns | 7.72 ns | 0.0665 |    2096 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,466.5 ns |  2.74 ns | 1.63 ns | 0.0788 |    2240 B |
| DefaultChain_ResolveIdentity                    | 1,159.3 ns |  8.32 ns | 5.50 ns | 0.0093 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,138.2 ns |  8.51 ns | 5.06 ns | 0.0091 |     368 B |
| UserAgentDetails_Build                          |   219.4 ns |  0.78 ns | 0.41 ns | 0.0201 |     576 B |
