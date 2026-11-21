```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean       | Error     | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,250.8 ns |  42.18 ns | 15.04 ns | 0.0658 |    1880 B |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1,002.7 ns |   2.39 ns |  0.85 ns | 0.0606 |    1800 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,049.2 ns |  21.00 ns |  7.49 ns | 0.0623 |    1872 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,529.4 ns | 107.52 ns | 38.34 ns | 0.0714 |    2096 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,615.5 ns | 143.47 ns | 51.16 ns | 0.0720 |    2240 B |
| DefaultChain_ResolveIdentity                    | 1,192.9 ns |   9.61 ns |  2.50 ns | 0.0094 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,236.3 ns |  22.98 ns |  8.20 ns | 0.0098 |     368 B |
| UserAgentDetails_Build                          |   244.2 ns |  37.48 ns | 13.37 ns | 0.0199 |     576 B |
