```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.91 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.370 μs | 0.0176 μs | 0.0092 μs | 0.0664 |    2088 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.464 μs | 0.0113 μs | 0.0075 μs | 0.0789 |    2232 B |
| DefaultChain_ResolveIdentity             | 1.229 μs | 0.0032 μs | 0.0017 μs | 0.0098 |     296 B |
| DefaultChain_ResolveIdentityAsync        | 1.223 μs | 0.0112 μs | 0.0067 μs | 0.0097 |     368 B |
