```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.35 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean       | Error    | StdDev   | Gen0   | Allocated |
|----------------- |-----------:|---------:|---------:|-------:|----------:|
| S3_Resolve       | 3,570.5 ns | 26.02 ns | 17.21 ns | 0.1691 |   4.74 KB |
| DynamoDB_Resolve |   879.1 ns |  4.64 ns |  2.76 ns | 0.0561 |   1.64 KB |
