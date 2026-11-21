```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.23 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean       | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|----------------------- |-----------:|---------:|---------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |   291.4 ns | 10.52 ns |  6.96 ns | 0.1262 | 0.0011 |   3.48 KB |
| Xml_SmallResponse      | 2,631.2 ns | 49.62 ns | 32.82 ns | 0.5325 | 0.0213 |  14.78 KB |
