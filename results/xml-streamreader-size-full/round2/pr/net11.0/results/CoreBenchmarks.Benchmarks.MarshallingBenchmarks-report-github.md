```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.32 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,413.7 ns | 378.24 ns | 250.18 ns | 1.0917 |      - |   31123 B |
| Xml_ListObjectsStructures | 77,099.7 ns | 351.49 ns | 209.16 ns | 1.2690 |      - |   37476 B |
| Xml_DateTimes             | 22,839.5 ns | 174.71 ns | 103.97 ns | 0.5499 |      - |   18002 B |
| Xml_WriteRequestBody      | 19,598.6 ns |  98.61 ns |  65.22 ns | 0.4711 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    162.2 ns |   3.36 ns |   2.00 ns | 0.0306 |      - |     880 B |
| Xml_SmallResponse         |  2,327.5 ns |   9.96 ns |   5.93 ns | 0.4479 | 0.0187 |   12876 B |
