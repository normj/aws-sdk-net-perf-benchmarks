```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.05 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.412 μs | 0.0088 μs | 0.0052 μs | 0.0602 |    1952 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.448 μs | 0.0140 μs | 0.0093 μs | 0.0685 |    2096 B |
| DefaultChain_ResolveIdentity             | 1.094 μs | 0.0025 μs | 0.0016 μs | 0.0044 |     152 B |
| DefaultChain_ResolveIdentityAsync        | 1.116 μs | 0.0037 μs | 0.0022 μs | 0.0045 |     224 B |
