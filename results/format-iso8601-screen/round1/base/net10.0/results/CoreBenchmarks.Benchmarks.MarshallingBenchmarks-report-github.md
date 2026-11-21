```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.16 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method             | Mean      | Error    | StdDev   | Gen0   | Allocated |
|------------------- |----------:|---------:|---------:|-------:|----------:|
| Format_ISO8601     | 149.93 ns | 3.818 ns | 1.361 ns | 0.0024 |      72 B |
| Format_ISO8601NoMs |  79.72 ns | 3.043 ns | 1.085 ns | 0.0022 |      64 B |
| Format_RFC822      | 116.29 ns | 3.194 ns | 1.139 ns | 0.0028 |      80 B |
