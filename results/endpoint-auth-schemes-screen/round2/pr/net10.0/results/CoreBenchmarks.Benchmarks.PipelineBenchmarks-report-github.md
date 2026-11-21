```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                             | Mean     | Error    | StdDev   | Gen0   | Allocated |
|----------------------------------- |---------:|---------:|---------:|-------:|----------:|
| EndpointAuthSchemes_SingleSigV4    | 22.89 ns | 0.111 ns | 0.039 ns |      - |         - |
| EndpointAuthSchemes_SigV4aAndSigV4 | 96.50 ns | 3.752 ns | 1.338 ns | 0.0077 |     224 B |
