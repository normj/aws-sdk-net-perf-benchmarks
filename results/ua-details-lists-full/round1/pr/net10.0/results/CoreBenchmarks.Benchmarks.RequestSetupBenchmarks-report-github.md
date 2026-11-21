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
| Method                                          | Mean        | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------ |------------:|----------:|----------:|-------:|----------:|
| Marshaller_PreInvoke                            | 1,100.82 ns |  1.766 ns |  1.051 ns | 0.0572 |    1704 B |
| AuthResolver_PreInvoke_ExplicitCredentials      |   975.94 ns | 42.062 ns | 27.822 ns | 0.0572 |    1648 B |
| AuthResolver_PreInvokeAsync_ExplicitCredentials |   996.53 ns |  4.952 ns |  2.947 ns | 0.0594 |    1720 B |
| AuthResolver_PreInvoke_DefaultChain             | 2,387.14 ns | 11.454 ns |  7.576 ns | 0.0667 |    1944 B |
| AuthResolver_PreInvokeAsync_DefaultChain        | 2,464.27 ns | 14.078 ns |  9.312 ns | 0.0690 |    2088 B |
| DefaultChain_ResolveIdentity                    | 1,159.19 ns |  8.729 ns |  4.565 ns | 0.0092 |     296 B |
| DefaultChain_ResolveIdentityAsync               | 1,148.85 ns | 16.903 ns | 11.180 ns | 0.0091 |     368 B |
| UserAgentDetails_Build                          |    79.32 ns |  0.214 ns |  0.127 ns | 0.0073 |     208 B |
