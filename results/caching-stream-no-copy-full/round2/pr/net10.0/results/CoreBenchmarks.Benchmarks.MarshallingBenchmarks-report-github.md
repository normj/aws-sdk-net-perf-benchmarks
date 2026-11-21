```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.02 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                | Mean       | Error    | StdDev  | Gen0   | Gen1   | Allocated |
|---------------------- |-----------:|---------:|--------:|-------:|-------:|----------:|
| Error_JsonNoMessage   |   897.4 ns | 11.90 ns | 7.87 ns | 0.0820 |      - |   2.34 KB |
| CachingStream_Read16K | 1,984.6 ns | 12.39 ns | 7.37 ns | 1.0272 | 0.0796 |  28.38 KB |
