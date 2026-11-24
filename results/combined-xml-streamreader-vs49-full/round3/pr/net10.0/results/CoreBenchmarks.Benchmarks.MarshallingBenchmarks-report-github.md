```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.39GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.59 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|----------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |    78.05 ns |  0.322 ns |  0.192 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse      | 2,508.19 ns | 57.796 ns | 38.229 ns | 0.4529 | 0.0201 |   12959 B |
