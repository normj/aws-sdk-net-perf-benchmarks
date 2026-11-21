```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.99 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev  | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|--------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,226.8 ns |  7.01 ns | 4.17 ns | 0.0635 |    1880 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   995.2 ns |  4.38 ns | 2.61 ns | 0.0638 |    1800 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,033.0 ns |  4.36 ns | 2.59 ns | 0.0659 |    1872 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,416.7 ns |  7.60 ns | 5.03 ns | 0.0688 |    2096 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,549.9 ns |  9.33 ns | 5.55 ns | 0.0715 |    2240 B |
| DefaultChain_ResolveIdentity                    | 1,180.9 ns | 13.90 ns | 9.19 ns | 0.0094 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,164.2 ns |  3.23 ns | 2.14 ns | 0.0093 |     368 B |
| UserAgentDetails_Build                          |   220.4 ns |  0.70 ns | 0.42 ns | 0.0203 |     576 B |
