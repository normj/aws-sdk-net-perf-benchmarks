```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method             | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------- |---------:|---------:|---------:|-------:|----------:|
| Format_ISO8601     | 21.15 ns | 0.164 ns | 0.108 ns | 0.0025 |      72 B |
| Format_ISO8601NoMs | 18.97 ns | 0.094 ns | 0.049 ns | 0.0023 |      64 B |
| Format_RFC822      | 21.32 ns | 0.089 ns | 0.053 ns | 0.0028 |      80 B |
