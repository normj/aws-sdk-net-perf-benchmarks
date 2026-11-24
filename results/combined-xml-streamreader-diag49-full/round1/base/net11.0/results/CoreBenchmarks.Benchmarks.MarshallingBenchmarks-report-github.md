```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.04 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,334.9 ns | 275.58 ns | 163.99 ns | 0.8484 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 79,621.7 ns | 168.85 ns |  88.31 ns | 1.2755 |      - |   36.6 KB |
| Xml_DateTimes             | 24,452.9 ns | 144.94 ns |  86.25 ns | 0.5850 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,480.7 ns |  21.74 ns |  11.37 ns | 0.4670 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    263.2 ns |   3.17 ns |   1.89 ns | 0.1261 | 0.0010 |   3.48 KB |
| Xml_SmallResponse         |  2,411.0 ns |   4.46 ns |   2.33 ns | 0.5311 |      - |  14.82 KB |
