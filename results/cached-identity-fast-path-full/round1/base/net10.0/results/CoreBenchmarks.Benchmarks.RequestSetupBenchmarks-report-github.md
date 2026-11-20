```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.403 μs | 0.0390 μs | 0.0232 μs | 0.0669 |    2096 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.487 μs | 0.0134 μs | 0.0070 μs | 0.0794 |    2240 B |
| DefaultChain_ResolveIdentity             | 1.174 μs | 0.0072 μs | 0.0043 μs | 0.0094 |     296 B |
| DefaultChain_ResolveIdentityAsync        | 1.178 μs | 0.0041 μs | 0.0022 μs | 0.0093 |     368 B |
