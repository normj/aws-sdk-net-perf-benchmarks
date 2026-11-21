```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 0.24 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                          | Mean        | Error      | StdDev     | Gen0   | Allocated |
|------------------------------------------------ |------------:|-----------:|-----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,382.71 ns | 294.850 ns | 195.025 ns | 0.0601 |    1704 B |
| AuthResolver_PreInvoke_ExplicitCredentials      | 1,004.43 ns |  27.790 ns |  18.381 ns | 0.0558 |    1648 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials | 1,008.19 ns |  38.450 ns |  20.110 ns | 0.0581 |    1720 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,747.65 ns | 269.091 ns | 177.987 ns | 0.0680 |    1944 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,526.54 ns |  38.110 ns |  25.208 ns | 0.0701 |    2088 B |
| DefaultChain_ResolveIdentity                    | 1,179.24 ns |   1.550 ns |   0.923 ns | 0.0103 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,177.68 ns |  35.349 ns |  23.381 ns | 0.0093 |     368 B |
| UserAgentDetails_Build                          |    86.65 ns |   2.544 ns |   1.514 ns | 0.0074 |     208 B |
