```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|---------:|---------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 72,994.0 ns | 788.3 ns | 469.1 ns | 0.8721 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 81,375.8 ns | 597.5 ns | 355.5 ns | 1.2953 |      - |  36.63 KB |
| Xml_DateTimes             | 25,717.0 ns | 202.7 ns | 120.6 ns | 0.5943 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 21,454.9 ns | 342.7 ns | 179.2 ns | 0.4328 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    530.5 ns | 262.8 ns | 173.8 ns | 0.1253 | 0.0014 |   3.48 KB |
| Xml_SmallResponse         |  3,855.2 ns | 371.4 ns | 245.6 ns | 0.5300 |      - |  14.83 KB |
