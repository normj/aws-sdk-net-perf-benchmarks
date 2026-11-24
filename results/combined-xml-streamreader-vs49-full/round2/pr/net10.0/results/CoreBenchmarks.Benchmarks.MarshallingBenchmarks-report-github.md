```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.59 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|----------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |    80.77 ns |  0.847 ns |  0.504 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse      | 2,434.10 ns | 75.024 ns | 49.624 ns | 0.4522 | 0.0105 |   12959 B |
