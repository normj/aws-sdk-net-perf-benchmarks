```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.83 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,127.96 ns |  9.041 ns | 5.980 ns | 0.0583 |    1704 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   964.56 ns |  1.143 ns | 0.598 ns | 0.0579 |    1648 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,011.91 ns |  6.724 ns | 4.447 ns | 0.0606 |    1720 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,365.71 ns | 12.145 ns | 7.227 ns | 0.0660 |    1944 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,447.50 ns | 10.324 ns | 6.828 ns | 0.0683 |    2088 B |
| DefaultChain_ResolveIdentity                    | 1,172.76 ns |  3.658 ns | 2.419 ns | 0.0094 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,159.51 ns |  4.961 ns | 3.281 ns | 0.0093 |     368 B |
| UserAgentDetails_Build                          |    76.56 ns |  0.122 ns | 0.072 ns | 0.0071 |     208 B |
