```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                                   | Mean     | Error     | StdDev    | Gen0   | Allocated |
|----------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| AuthResolver_PreInvoke_DefaultChain      | 2.180 μs | 0.0177 μs | 0.0117 μs | 0.0615 |    1944 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.236 μs | 0.0189 μs | 0.0125 μs | 0.0713 |    2088 B |
| DefaultChain_ResolveIdentity             | 1.083 μs | 0.0078 μs | 0.0041 μs | 0.0043 |     152 B |
| DefaultChain_ResolveIdentityAsync        | 1.116 μs | 0.0119 μs | 0.0079 μs | 0.0044 |     224 B |
