```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.5 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,205.1 ns | 284.35 ns | 188.08 ns | 1.1013 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 76,978.6 ns | 401.33 ns | 265.45 ns | 1.2255 |      - |   36.6 KB |
| Xml_DateTimes             | 22,757.6 ns |  76.06 ns |  45.26 ns | 0.6350 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,768.7 ns |  78.96 ns |  46.99 ns | 0.4741 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    268.0 ns |   1.10 ns |   0.73 ns | 0.1255 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,413.2 ns |  19.94 ns |  11.87 ns | 0.5303 |      - |  14.82 KB |
