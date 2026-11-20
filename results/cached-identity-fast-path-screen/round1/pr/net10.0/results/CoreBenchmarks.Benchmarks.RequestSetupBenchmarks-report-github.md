```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.298 μs | 0.0218 μs | 0.0078 μs | 0.0640 |    1952 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.421 μs | 0.0041 μs | 0.0015 μs | 0.0678 |    2096 B |
| DefaultChain_ResolveIdentity             | 1.080 μs | 0.0061 μs | 0.0016 μs | 0.0043 |     152 B |
| DefaultChain_ResolveIdentityAsync        | 1.100 μs | 0.0053 μs | 0.0014 μs | 0.0044 |     224 B |
