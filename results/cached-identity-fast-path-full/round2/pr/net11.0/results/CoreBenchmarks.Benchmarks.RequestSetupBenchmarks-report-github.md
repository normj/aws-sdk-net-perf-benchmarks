```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.38GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.03 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.246 μs | 0.0142 μs | 0.0085 μs | 0.0634 |    1944 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.310 μs | 0.0182 μs | 0.0120 μs | 0.0736 |    2088 B |
| DefaultChain_ResolveIdentity             | 1.091 μs | 0.0036 μs | 0.0019 μs | 0.0044 |     152 B |
| DefaultChain_ResolveIdentityAsync        | 1.112 μs | 0.0060 μs | 0.0036 μs | 0.0044 |     224 B |
