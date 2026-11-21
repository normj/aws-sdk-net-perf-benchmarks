```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.85 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean     | Error    | StdDev  | Gen0   | Allocated |
|-------------------- |---------:|---------:|--------:|-------:|----------:|
| Error_Json          | 915.1 ns | 12.25 ns | 7.29 ns | 0.0653 |   1.86 KB |
| Error_JsonNoMessage | 859.3 ns | 12.55 ns | 8.30 ns | 0.0668 |   1.91 KB |
