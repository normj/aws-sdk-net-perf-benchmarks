```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                | Mean       | Error   | StdDev  | Gen0   | Gen1   | Allocated |
|---------------------- |-----------:|--------:|--------:|-------:|-------:|----------:|
| Error_JsonNoMessage   |   869.1 ns | 2.85 ns | 1.70 ns | 0.0860 |      - |   2.38 KB |
| CachingStream_Read16K | 2,885.4 ns | 6.98 ns | 3.65 ns | 1.5984 | 0.1042 |  44.34 KB |
