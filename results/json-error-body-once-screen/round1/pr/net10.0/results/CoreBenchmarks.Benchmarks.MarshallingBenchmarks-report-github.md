```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.18 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method              | Mean     | Error    | StdDev  | Gen0   | Allocated |
|-------------------- |---------:|---------:|--------:|-------:|----------:|
| Error_Json          | 831.2 ns | 12.45 ns | 4.44 ns | 0.0528 |   1.48 KB |
| Error_JsonNoMessage | 710.2 ns |  7.92 ns | 2.06 ns | 0.0508 |   1.41 KB |
