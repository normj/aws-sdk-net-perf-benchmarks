```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.320 μs | 0.0205 μs | 0.0135 μs | 0.0650 |    2088 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.421 μs | 0.0121 μs | 0.0080 μs | 0.0773 |    2232 B |
| DefaultChain_ResolveIdentity             | 1.203 μs | 0.0118 μs | 0.0078 μs | 0.0096 |     296 B |
| DefaultChain_ResolveIdentityAsync        | 1.202 μs | 0.0126 μs | 0.0083 μs | 0.0096 |     368 B |
