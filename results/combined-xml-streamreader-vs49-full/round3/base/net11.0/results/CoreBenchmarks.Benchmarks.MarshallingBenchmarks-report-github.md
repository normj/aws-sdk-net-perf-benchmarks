```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.61 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|----------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |    76.68 ns |  1.095 ns |  0.652 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse      | 2,447.98 ns | 37.358 ns | 24.710 ns | 0.5316 | 0.0197 |   15224 B |
