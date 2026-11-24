```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,183.4 ns | 4,508.22 ns | 2,981.91 ns | 1.1013 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 78,415.2 ns |   536.12 ns |   354.61 ns | 1.2438 |      - |   36.6 KB |
| Xml_DateTimes             | 22,897.4 ns |   300.48 ns |   178.81 ns | 0.6350 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 20,182.2 ns |   111.71 ns |    66.48 ns | 0.4747 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    276.5 ns |    15.96 ns |    10.56 ns | 0.1262 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,636.3 ns |    24.84 ns |    16.43 ns | 0.5361 |      - |  14.82 KB |
