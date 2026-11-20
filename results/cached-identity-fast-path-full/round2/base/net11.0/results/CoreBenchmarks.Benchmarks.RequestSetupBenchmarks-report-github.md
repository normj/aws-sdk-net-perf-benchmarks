```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.426 μs | 0.0304 μs | 0.0159 μs | 0.0675 |    2088 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.474 μs | 0.0158 μs | 0.0104 μs | 0.0789 |    2232 B |
| DefaultChain_ResolveIdentity             | 1.284 μs | 0.1091 μs | 0.0721 μs | 0.0099 |     296 B |
| DefaultChain_ResolveIdentityAsync        | 1.221 μs | 0.0105 μs | 0.0069 μs | 0.0098 |     368 B |
