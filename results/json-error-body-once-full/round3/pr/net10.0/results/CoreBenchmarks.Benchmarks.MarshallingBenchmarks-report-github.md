```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.67 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean     | Error   | StdDev  | Gen0   | Allocated |
|-------------------- |---------:|--------:|--------:|-------:|----------:|
| Error_Json          | 827.2 ns | 3.93 ns | 2.05 ns | 0.0531 |   1.48 KB |
| Error_JsonNoMessage | 705.3 ns | 2.97 ns | 1.77 ns | 0.0506 |   1.41 KB |
