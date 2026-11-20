```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.48 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean         | Error       | StdDev      | Gen0   | Allocated |
|----------------- |-------------:|------------:|------------:|-------:|----------:|
| S3_Resolve       | 4,521.015 ns | 458.5946 ns | 303.3319 ns | 0.1783 |    5456 B |
| Substring_Suffix |     8.306 ns |   0.3315 ns |   0.2193 ns | 0.0014 |      40 B |
