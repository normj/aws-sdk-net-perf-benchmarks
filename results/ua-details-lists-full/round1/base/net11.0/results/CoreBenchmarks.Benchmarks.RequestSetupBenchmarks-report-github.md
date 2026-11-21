```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.97 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------------------------------ |-----------:|---------:|---------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,086.3 ns |  9.99 ns |  6.61 ns | 0.0650 |    1880 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   883.8 ns | 13.96 ns |  9.24 ns | 0.0603 |    1792 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   899.1 ns | 16.84 ns | 10.02 ns | 0.0655 |    1864 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,477.3 ns | 18.66 ns | 12.34 ns | 0.0689 |    2088 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,442.5 ns | 15.78 ns | 10.44 ns | 0.0776 |    2232 B |
| DefaultChain_ResolveIdentity                    | 1,201.8 ns |  4.09 ns |  2.71 ns | 0.0096 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,196.9 ns | 12.17 ns |  8.05 ns | 0.0095 |     368 B |
| UserAgentDetails_Build                          |   215.0 ns |  1.24 ns |  0.74 ns | 0.0197 |     576 B |
