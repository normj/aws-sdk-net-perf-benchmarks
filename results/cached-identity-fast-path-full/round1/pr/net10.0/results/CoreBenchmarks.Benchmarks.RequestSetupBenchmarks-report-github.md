```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.39 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.376 μs | 0.0084 μs | 0.0056 μs | 0.0672 |    1952 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.437 μs | 0.0166 μs | 0.0099 μs | 0.0684 |    2096 B |
| DefaultChain_ResolveIdentity             | 1.071 μs | 0.0019 μs | 0.0012 μs | 0.0043 |     152 B |
| DefaultChain_ResolveIdentityAsync        | 1.088 μs | 0.0029 μs | 0.0017 μs | 0.0044 |     224 B |
