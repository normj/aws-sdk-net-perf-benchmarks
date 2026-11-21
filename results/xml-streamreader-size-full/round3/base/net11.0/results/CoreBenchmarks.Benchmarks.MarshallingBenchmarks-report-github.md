```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.36 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,660.6 ns | 993.23 ns | 656.96 ns | 0.8296 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 79,220.6 ns | 606.11 ns | 400.91 ns | 1.2563 |      - |   36.6 KB |
| Xml_DateTimes             | 22,974.3 ns | 178.55 ns | 106.25 ns | 0.5539 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,641.2 ns |  42.53 ns |  25.31 ns | 0.4711 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    268.2 ns |   1.08 ns |   0.64 ns | 0.1259 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,624.3 ns |  23.08 ns |  15.26 ns | 0.5328 |      - |  14.82 KB |
