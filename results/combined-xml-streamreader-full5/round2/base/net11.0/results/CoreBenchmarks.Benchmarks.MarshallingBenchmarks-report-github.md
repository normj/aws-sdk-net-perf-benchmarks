```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.37 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,902.0 ns | 873.14 ns | 577.53 ns | 0.8296 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,484.1 ns | 680.97 ns | 450.42 ns | 1.2315 |      - |   36.6 KB |
| Xml_DateTimes             | 23,009.1 ns | 144.44 ns |  95.54 ns | 0.5556 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,666.7 ns | 138.43 ns |  82.38 ns | 0.4688 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    275.7 ns |   1.74 ns |   1.15 ns | 0.1260 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,441.1 ns |  35.64 ns |  23.57 ns | 0.5363 |      - |  14.82 KB |
