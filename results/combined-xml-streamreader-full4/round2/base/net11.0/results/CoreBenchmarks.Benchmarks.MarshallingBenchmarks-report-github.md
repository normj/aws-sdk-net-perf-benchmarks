```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.79 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,433.8 ns | 491.79 ns | 292.66 ns | 1.0965 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 76,775.9 ns | 266.03 ns | 175.96 ns | 1.2255 |      - |   36.6 KB |
| Xml_DateTimes             | 22,766.6 ns |  46.66 ns |  24.40 ns | 0.6368 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,578.7 ns |  60.46 ns |  35.98 ns | 0.4693 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    259.5 ns |   0.81 ns |   0.48 ns | 0.1261 | 0.0010 |   3.48 KB |
| Xml_SmallResponse         |  2,352.3 ns |  10.10 ns |   6.68 ns | 0.5356 |      - |  14.82 KB |
