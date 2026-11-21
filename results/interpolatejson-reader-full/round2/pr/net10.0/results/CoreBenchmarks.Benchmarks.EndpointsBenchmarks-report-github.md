```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.57 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean       | Error    | StdDev  | Gen0   | Allocated |
|----------------- |-----------:|---------:|--------:|-------:|----------:|
| S3_Resolve       | 3,807.6 ns | 15.24 ns | 9.07 ns | 0.1681 |   4.73 KB |
| DynamoDB_Resolve |   877.4 ns |  3.73 ns | 2.22 ns | 0.0563 |   1.64 KB |
