```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method             | Mean     | Error     | StdDev   | Gen0   | Allocated |
|------------------- |---------:|----------:|---------:|-------:|----------:|
| Format_ISO8601     | 31.96 ns | 11.785 ns | 7.795 ns | 0.0025 |      72 B |
| Format_ISO8601NoMs | 31.23 ns |  7.516 ns | 4.971 ns | 0.0022 |      64 B |
| Format_RFC822      | 33.92 ns | 10.568 ns | 6.990 ns | 0.0028 |      80 B |
