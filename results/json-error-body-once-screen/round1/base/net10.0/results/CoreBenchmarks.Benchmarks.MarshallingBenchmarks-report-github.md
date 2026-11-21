```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.07 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method              | Mean       | Error     | StdDev   | Gen0   | Allocated |
|-------------------- |-----------:|----------:|---------:|-------:|----------:|
| Error_Json          | 1,009.1 ns | 205.80 ns | 73.39 ns | 0.0792 |   2.28 KB |
| Error_JsonNoMessage |   905.5 ns |  14.00 ns |  4.99 ns | 0.0831 |   2.38 KB |
