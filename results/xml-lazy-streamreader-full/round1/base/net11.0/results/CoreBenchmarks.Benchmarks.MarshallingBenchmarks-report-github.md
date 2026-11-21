```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.57 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean       | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|----------------------- |-----------:|---------:|---------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |   262.2 ns |  7.32 ns |  4.84 ns | 0.1255 | 0.0010 |   3.48 KB |
| Xml_SmallResponse      | 2,386.5 ns | 45.89 ns | 30.35 ns | 0.5344 | 0.0095 |  14.85 KB |
