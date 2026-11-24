```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.63 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,089.6 ns | 570.57 ns | 339.54 ns | 1.1013 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 76,882.4 ns | 547.70 ns | 325.93 ns | 1.2255 |      - |   36.6 KB |
| Xml_DateTimes             | 22,883.5 ns | 135.28 ns |  89.48 ns | 0.5531 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 20,023.6 ns | 650.23 ns | 386.94 ns | 0.4106 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    268.8 ns |   2.86 ns |   1.89 ns | 0.1258 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,391.4 ns |  15.66 ns |   9.32 ns | 0.5301 |      - |  14.82 KB |
