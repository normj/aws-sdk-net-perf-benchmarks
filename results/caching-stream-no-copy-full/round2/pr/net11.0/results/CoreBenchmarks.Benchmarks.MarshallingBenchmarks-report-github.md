```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.02 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                | Mean       | Error    | StdDev  | Gen0   | Gen1   | Allocated |
|---------------------- |-----------:|---------:|--------:|-------:|-------:|----------:|
| Error_JsonNoMessage   |   849.6 ns | 13.84 ns | 9.15 ns | 0.0845 |      - |   2.34 KB |
| CachingStream_Read16K | 1,954.6 ns | 12.17 ns | 8.05 ns | 1.0277 | 0.0779 |  28.38 KB |
