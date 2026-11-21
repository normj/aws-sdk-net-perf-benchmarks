```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                | Mean       | Error     | StdDev   | Gen0   | Gen1   | Allocated |
|---------------------- |-----------:|----------:|---------:|-------:|-------:|----------:|
| Error_JsonNoMessage   |   882.2 ns |   2.95 ns |  1.54 ns | 0.0815 |      - |   2.34 KB |
| CachingStream_Read16K | 2,011.6 ns | 134.87 ns | 89.21 ns | 1.0286 | 0.0779 |  28.38 KB |
