```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method             | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------- |---------:|---------:|---------:|-------:|----------:|
| Format_ISO8601     | 23.36 ns | 0.100 ns | 0.066 ns | 0.0025 |      72 B |
| Format_ISO8601NoMs | 17.92 ns | 0.158 ns | 0.105 ns | 0.0022 |      64 B |
| Format_RFC822      | 26.28 ns | 0.285 ns | 0.170 ns | 0.0028 |      80 B |
