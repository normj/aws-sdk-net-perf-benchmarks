```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.384 μs | 0.0136 μs | 0.0071 μs | 0.0665 |    2096 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.396 μs | 0.0096 μs | 0.0057 μs | 0.0766 |    2240 B |
| DefaultChain_ResolveIdentity             | 1.162 μs | 0.0044 μs | 0.0026 μs | 0.0093 |     296 B |
| DefaultChain_ResolveIdentityAsync        | 1.146 μs | 0.0027 μs | 0.0016 μs | 0.0092 |     368 B |
