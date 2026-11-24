```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.35 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean       | Error    | StdDev   | Gen0   | Allocated |
|----------------- |-----------:|---------:|---------:|-------:|----------:|
| S3_Resolve       | 3,230.5 ns | 11.28 ns |  5.90 ns | 0.1682 |   4.74 KB |
| DynamoDB_Resolve |   840.7 ns | 16.01 ns | 10.59 ns | 0.0562 |   1.64 KB |
