```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.13 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean       | Error     | StdDev   | Gen0   | Gen1   | Allocated |
|----------------------- |-----------:|----------:|---------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |   269.4 ns |   6.85 ns |  4.08 ns | 0.1254 | 0.0011 |   3.48 KB |
| Xml_SmallResponse      | 2,474.9 ns | 122.09 ns | 80.75 ns | 0.5350 | 0.0097 |  14.85 KB |
