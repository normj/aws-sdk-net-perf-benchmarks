```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,428.2 ns | 514.82 ns | 306.36 ns | 0.8446 |      - |   31141 B |
| Xml_ListObjectsStructures | 78,670.1 ns | 514.78 ns | 340.49 ns | 1.2563 |      - |   37483 B |
| Xml_DateTimes             | 22,994.7 ns | 130.25 ns |  68.12 ns | 0.5531 |      - |   18020 B |
| Xml_WriteRequestBody      | 19,627.9 ns | 196.04 ns | 129.67 ns | 0.4676 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    100.1 ns |   0.78 ns |   0.46 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,341.9 ns |   4.42 ns |   2.31 ns | 0.4548 | 0.0190 |   12960 B |
