```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.17 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean       | Error    | StdDev  | Gen0   | Allocated |
|----------------- |-----------:|---------:|--------:|-------:|----------:|
| S3_Resolve       | 3,229.5 ns | 12.32 ns | 7.33 ns | 0.1687 |   4.74 KB |
| DynamoDB_Resolve |   816.0 ns |  2.94 ns | 1.75 ns | 0.0587 |   1.64 KB |
