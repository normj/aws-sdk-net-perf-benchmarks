```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 7.1 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                 | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|----------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_HeaderOnlyResponse |    73.15 ns |  2.898 ns |  1.917 ns | 0.0105 |      - |     296 B |
| Xml_SmallResponse      | 2,336.63 ns | 41.286 ns | 24.569 ns | 0.5324 | 0.0285 |   15224 B |
