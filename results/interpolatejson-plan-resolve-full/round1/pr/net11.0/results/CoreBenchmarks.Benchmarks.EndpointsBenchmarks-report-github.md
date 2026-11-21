```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.46 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean       | Error    | StdDev  | Gen0   | Allocated |
|----------------- |-----------:|---------:|--------:|-------:|----------:|
| S3_Resolve       | 2,896.6 ns | 17.23 ns | 9.01 ns | 0.1625 |   4.69 KB |
| DynamoDB_Resolve |   854.3 ns | 13.52 ns | 8.05 ns | 0.0578 |   1.64 KB |
