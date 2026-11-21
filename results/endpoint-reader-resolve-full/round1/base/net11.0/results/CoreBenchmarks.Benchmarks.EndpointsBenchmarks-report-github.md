```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean       | Error    | StdDev   | Gen0   | Allocated |
|----------------- |-----------:|---------:|---------:|-------:|----------:|
| S3_Resolve       | 4,100.7 ns | 62.70 ns | 37.31 ns | 0.1800 |   5.33 KB |
| DynamoDB_Resolve |   836.5 ns |  2.84 ns |  1.69 ns | 0.0570 |   1.64 KB |
