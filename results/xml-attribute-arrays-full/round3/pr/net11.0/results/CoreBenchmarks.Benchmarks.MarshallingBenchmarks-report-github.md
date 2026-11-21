```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,323.2 ns | 311.03 ns | 205.72 ns | 0.8296 |      - |  30.17 KB |
| Xml_ListObjectsStructures | 77,246.9 ns | 585.55 ns | 348.45 ns | 1.2255 |      - |  36.37 KB |
| Xml_DateTimes             | 23,050.7 ns | 184.36 ns | 121.95 ns | 0.5515 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,550.8 ns | 195.05 ns | 116.07 ns | 0.4658 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    273.5 ns |   0.79 ns |   0.52 ns | 0.1258 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,339.4 ns |  12.28 ns |   8.12 ns | 0.5207 | 0.0093 |   14.6 KB |
