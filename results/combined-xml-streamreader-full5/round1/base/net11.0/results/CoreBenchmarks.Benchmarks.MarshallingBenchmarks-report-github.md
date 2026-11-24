```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,540.4 ns | 482.12 ns | 318.89 ns | 1.1013 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 76,296.6 ns |  89.45 ns |  46.78 ns | 1.2195 |      - |   36.6 KB |
| Xml_DateTimes             | 22,866.6 ns | 120.69 ns |  71.82 ns | 0.6378 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,564.6 ns |  37.69 ns |  19.71 ns | 0.4693 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    282.5 ns |   3.40 ns |   2.25 ns | 0.1254 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,400.6 ns |   8.21 ns |   4.29 ns | 0.5340 |      - |  14.82 KB |
