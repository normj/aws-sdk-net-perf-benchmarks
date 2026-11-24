```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,559.0 ns | 484.93 ns | 320.75 ns | 0.8296 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 78,118.3 ns | 102.46 ns |  53.59 ns | 1.2500 |      - |   36.6 KB |
| Xml_DateTimes             | 22,987.5 ns | 115.79 ns |  76.59 ns | 0.5490 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,580.7 ns |  92.32 ns |  54.94 ns | 0.4682 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    269.8 ns |   1.58 ns |   1.04 ns | 0.1261 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,651.6 ns |  12.85 ns |   8.50 ns | 0.5363 |      - |  14.82 KB |
