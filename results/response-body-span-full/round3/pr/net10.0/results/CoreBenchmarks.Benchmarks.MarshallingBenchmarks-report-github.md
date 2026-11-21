```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean     | Error    | StdDev  | Gen0   | Allocated |
|-------------------- |---------:|---------:|--------:|-------:|----------:|
| Error_Json          | 959.5 ns | 17.56 ns | 9.18 ns | 0.0638 |   1.86 KB |
| Error_JsonNoMessage | 887.3 ns | 15.04 ns | 7.87 ns | 0.0669 |   1.91 KB |
