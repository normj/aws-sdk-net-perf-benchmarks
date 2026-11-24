```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.83 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,555.2 ns | 161.19 ns |  95.92 ns | 1.0917 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,859.1 ns | 853.82 ns | 564.75 ns | 1.2376 |      - |   36.6 KB |
| Xml_DateTimes             | 22,810.7 ns |  83.77 ns |  43.81 ns | 0.6378 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,681.0 ns |  99.66 ns |  65.92 ns | 0.4741 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    272.5 ns |   2.60 ns |   1.55 ns | 0.1256 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,454.5 ns |  18.95 ns |  11.28 ns | 0.5372 |      - |  14.82 KB |
