```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.11 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method              | Mean       | Error     | StdDev    | Gen0   | Allocated |
|-------------------- |-----------:|----------:|----------:|-------:|----------:|
| Error_Json          | 1,002.3 ns | 224.95 ns | 148.79 ns | 0.0524 |   1.48 KB |
| Error_JsonNoMessage |   739.2 ns |  15.92 ns |  10.53 ns | 0.0505 |   1.41 KB |
