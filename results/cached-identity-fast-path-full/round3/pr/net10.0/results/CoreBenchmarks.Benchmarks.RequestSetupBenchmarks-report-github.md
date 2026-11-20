```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.37 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.320 μs | 0.0105 μs | 0.0063 μs | 0.0649 |    1952 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.347 μs | 0.0089 μs | 0.0053 μs | 0.0658 |    2096 B |
| DefaultChain_ResolveIdentity             | 1.064 μs | 0.0100 μs | 0.0066 μs | 0.0042 |     152 B |
| DefaultChain_ResolveIdentityAsync        | 1.072 μs | 0.0024 μs | 0.0016 μs | 0.0043 |     224 B |
