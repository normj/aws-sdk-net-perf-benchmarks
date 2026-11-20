```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.78 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method               | Mean      | Error    | StdDev   | Gen0   | Allocated |
|--------------------- |----------:|---------:|---------:|-------:|----------:|
| ParseArn_NotArn      |  12.89 ns | 0.369 ns | 0.132 ns |      - |         - |
| ParseArn_AccessPoint | 406.18 ns | 6.902 ns | 2.461 ns | 0.0373 |    1088 B |
