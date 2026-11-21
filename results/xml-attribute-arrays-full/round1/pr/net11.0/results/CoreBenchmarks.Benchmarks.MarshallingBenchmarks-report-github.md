```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.73 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,484.8 ns | 307.37 ns | 160.76 ns | 0.8484 |      - |  30.17 KB |
| Xml_ListObjectsStructures | 76,904.2 ns | 546.13 ns | 361.23 ns | 1.2255 |      - |  36.37 KB |
| Xml_DateTimes             | 22,982.7 ns | 209.22 ns | 124.50 ns | 0.5515 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,675.1 ns |  38.40 ns |  22.85 ns | 0.4711 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    276.6 ns |  13.76 ns |   9.10 ns | 0.1263 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,314.5 ns |  19.25 ns |  11.46 ns | 0.5262 | 0.0092 |   14.6 KB |
