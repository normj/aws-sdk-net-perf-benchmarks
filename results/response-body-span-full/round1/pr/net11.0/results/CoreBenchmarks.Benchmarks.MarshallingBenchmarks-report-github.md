```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.35 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean     | Error    | StdDev  | Gen0   | Allocated |
|-------------------- |---------:|---------:|--------:|-------:|----------:|
| Error_Json          | 848.9 ns |  7.44 ns | 4.42 ns | 0.0651 |   1.86 KB |
| Error_JsonNoMessage | 800.8 ns | 14.31 ns | 8.52 ns | 0.0669 |   1.91 KB |
