```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                | Mean     | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|---------------------- |---------:|----------:|----------:|-------:|-------:|----------:|
| Error_JsonNoMessage   | 1.017 μs | 0.0635 μs | 0.0226 μs | 0.0844 |      - |   2.38 KB |
| CachingStream_Read16K | 3.170 μs | 0.1409 μs | 0.0502 μs | 1.6070 | 0.1062 |  44.34 KB |
