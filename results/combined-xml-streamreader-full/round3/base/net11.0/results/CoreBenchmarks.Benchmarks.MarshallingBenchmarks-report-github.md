```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.46GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,893.5 ns |   593.70 ns |   310.52 ns | 1.0965 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,123.5 ns |   320.84 ns |   190.93 ns | 1.2376 |      - |   36.6 KB |
| Xml_DateTimes             | 22,991.5 ns |   187.50 ns |   111.58 ns | 0.5482 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 21,223.9 ns | 5,499.01 ns | 3,272.37 ns | 0.4682 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    266.6 ns |     1.46 ns |     0.87 ns | 0.1258 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,434.3 ns |    13.64 ns |     8.11 ns | 0.5334 |      - |  14.82 KB |
