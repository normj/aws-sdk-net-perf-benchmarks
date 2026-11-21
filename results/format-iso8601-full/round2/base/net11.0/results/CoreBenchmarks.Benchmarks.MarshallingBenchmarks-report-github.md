```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.63 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method             | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------------------- |----------:|---------:|---------:|-------:|----------:|
| Format_ISO8601     | 153.70 ns | 5.612 ns | 3.712 ns | 0.0023 |      72 B |
| Format_ISO8601NoMs |  84.80 ns | 3.248 ns | 2.148 ns | 0.0023 |      64 B |
| Format_RFC822      | 113.88 ns | 2.578 ns | 1.534 ns | 0.0027 |      80 B |
