```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.31 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,914.9 ns | 721.22 ns | 429.19 ns | 0.8562 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,036.6 ns | 245.91 ns | 146.34 ns | 1.2887 |      - |  36.63 KB |
| Xml_DateTimes             | 23,862.3 ns | 207.39 ns | 137.18 ns | 0.5734 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 21,042.3 ns | 192.25 ns | 127.16 ns | 0.4217 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    288.8 ns |   1.16 ns |   0.77 ns | 0.1262 | 0.0012 |   3.48 KB |
| Xml_SmallResponse         |  2,592.0 ns |  17.29 ns |   9.04 ns | 0.5362 |      - |  14.83 KB |
