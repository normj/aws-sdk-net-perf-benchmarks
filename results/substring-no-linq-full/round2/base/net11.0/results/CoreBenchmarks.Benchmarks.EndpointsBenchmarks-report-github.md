```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method           | Mean        | Error     | StdDev    | Gen0   | Allocated |
|----------------- |------------:|----------:|----------:|-------:|----------:|
| S3_Resolve       | 4,079.66 ns | 28.443 ns | 18.813 ns | 0.1793 |    5456 B |
| Substring_Suffix |    22.76 ns |  0.200 ns |  0.119 ns | 0.0014 |      40 B |
