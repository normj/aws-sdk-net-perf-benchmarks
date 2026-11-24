```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,034.8 ns | 296.01 ns | 176.15 ns | 0.8371 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,985.6 ns | 442.05 ns | 292.39 ns | 1.2376 |      - |   36.6 KB |
| Xml_DateTimes             | 22,686.1 ns | 146.80 ns |  97.10 ns | 0.6341 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,834.8 ns | 191.57 ns | 114.00 ns | 0.4741 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    266.0 ns |   2.55 ns |   1.69 ns | 0.1262 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,417.7 ns |  29.30 ns |  17.44 ns | 0.5324 |      - |  14.82 KB |
