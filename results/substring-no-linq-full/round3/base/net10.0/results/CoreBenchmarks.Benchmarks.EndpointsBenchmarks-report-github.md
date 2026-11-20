```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.45GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.87 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean        | Error     | StdDev    | Gen0   | Allocated |
|----------------- |------------:|----------:|----------:|-------:|----------:|
| S3_Resolve       | 4,414.75 ns | 40.304 ns | 21.080 ns | 0.1814 |    5456 B |
| Substring_Suffix |    23.57 ns |  2.770 ns |  1.832 ns | 0.0014 |      40 B |
