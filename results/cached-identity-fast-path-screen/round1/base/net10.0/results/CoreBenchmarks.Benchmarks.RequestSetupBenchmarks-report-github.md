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
| AuthResolver_PreInvoke_DefaultChain      | 2.430 μs | 0.0969 μs | 0.0252 μs | 0.0693 |    2096 B |
| AuthResolver_PreInvokeAsync_DefaultChain | 2.452 μs | 0.0559 μs | 0.0199 μs | 0.0781 |    2240 B |
| DefaultChain_ResolveIdentity             | 1.179 μs | 0.0039 μs | 0.0010 μs | 0.0094 |     296 B |
| DefaultChain_ResolveIdentityAsync        | 1.150 μs | 0.0022 μs | 0.0008 μs | 0.0092 |     368 B |
