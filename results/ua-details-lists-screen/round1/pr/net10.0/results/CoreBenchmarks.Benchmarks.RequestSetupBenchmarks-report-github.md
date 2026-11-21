```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,203.90 ns | 100.98 ns | 36.011 ns | 0.0567 |    1704 B |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1,030.47 ns | 113.85 ns | 40.601 ns | 0.0554 |    1648 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,063.91 ns |  95.64 ns | 34.105 ns | 0.0577 |    1720 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,564.85 ns |  99.13 ns | 35.349 ns | 0.0615 |    1944 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,542.65 ns | 117.01 ns | 41.727 ns | 0.0714 |    2088 B |
| DefaultChain_ResolveIdentity                    | 1,178.84 ns |  12.31 ns |  4.389 ns | 0.0094 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,169.15 ns |  24.35 ns |  8.684 ns | 0.0093 |     368 B |
| UserAgentDetails_Build                          |    85.29 ns |  12.46 ns |  4.442 ns | 0.0073 |     208 B |
