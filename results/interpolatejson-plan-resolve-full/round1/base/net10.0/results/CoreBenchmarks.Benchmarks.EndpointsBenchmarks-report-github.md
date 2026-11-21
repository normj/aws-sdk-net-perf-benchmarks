```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.42GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean       | Error     | StdDev   | Gen0   | Allocated |
|----------------- |-----------:|----------:|---------:|-------:|----------:|
| S3_Resolve       | 4,500.3 ns | 119.90 ns | 79.31 ns | 0.1817 |   5.33 KB |
| DynamoDB_Resolve |   894.8 ns |  18.22 ns | 12.05 ns | 0.0560 |   1.64 KB |
