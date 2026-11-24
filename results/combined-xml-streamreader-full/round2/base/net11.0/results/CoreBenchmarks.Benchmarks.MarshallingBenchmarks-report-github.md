```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.66 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,951.9 ns |   711.19 ns |   371.97 ns | 1.1013 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 76,772.4 ns |   384.52 ns |   201.11 ns | 1.2195 |      - |   36.6 KB |
| Xml_DateTimes             | 22,800.1 ns |   252.85 ns |   150.47 ns | 0.6359 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 20,498.9 ns | 3,060.65 ns | 1,600.78 ns | 0.4735 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    257.7 ns |     0.53 ns |     0.31 ns | 0.1256 | 0.0010 |   3.48 KB |
| Xml_SmallResponse         |  2,411.0 ns |    10.46 ns |     6.23 ns | 0.5289 |      - |  14.82 KB |
