```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method             | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------- |---------:|---------:|---------:|-------:|----------:|
| Format_ISO8601     | 21.32 ns | 0.978 ns | 0.647 ns | 0.0025 |      72 B |
| Format_ISO8601NoMs | 17.71 ns | 0.099 ns | 0.052 ns | 0.0022 |      64 B |
| Format_RFC822      | 21.79 ns | 0.185 ns | 0.123 ns | 0.0028 |      80 B |
