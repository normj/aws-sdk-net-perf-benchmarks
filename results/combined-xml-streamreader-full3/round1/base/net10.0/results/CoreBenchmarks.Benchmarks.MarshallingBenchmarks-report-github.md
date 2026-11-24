```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,341.2 ns | 297.26 ns | 155.47 ns | 0.8523 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 79,681.7 ns |  96.52 ns |  57.44 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,518.9 ns | 106.89 ns |  70.70 ns | 0.5673 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,773.4 ns | 113.40 ns |  59.31 ns | 0.4150 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    287.1 ns |   1.01 ns |   0.53 ns | 0.1255 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,536.0 ns |   4.05 ns |   2.12 ns | 0.5290 |      - |  14.83 KB |
