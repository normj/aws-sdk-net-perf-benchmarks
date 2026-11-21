```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.35 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |-----------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,125.5 ns |  16.97 ns |   8.88 ns | 0.0631 |    1880 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   910.8 ns |  60.01 ns |  35.71 ns | 0.0607 |    1792 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   913.5 ns |  15.60 ns |  10.32 ns | 0.0659 |    1864 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,508.6 ns |  60.87 ns |  36.22 ns | 0.0691 |    2088 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,951.0 ns | 493.29 ns | 326.28 ns | 0.0722 |    2232 B |
| DefaultChain_ResolveIdentity                    | 1,275.9 ns |  88.10 ns |  46.08 ns | 0.0063 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,266.3 ns |  29.08 ns |  17.31 ns | 0.0101 |     368 B |
| UserAgentDetails_Build                          |   262.7 ns |  75.99 ns |  50.26 ns | 0.0200 |     576 B |
