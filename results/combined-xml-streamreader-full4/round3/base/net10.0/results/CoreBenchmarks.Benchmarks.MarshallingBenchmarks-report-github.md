```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,775.6 ns | 858.01 ns | 567.52 ns | 0.8523 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 79,770.0 ns | 376.89 ns | 224.28 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,631.9 ns | 145.52 ns |  96.25 ns | 0.5673 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,653.5 ns |  78.41 ns |  46.66 ns | 0.4128 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    279.1 ns |   3.24 ns |   2.15 ns | 0.1260 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,551.0 ns |   7.83 ns |   5.18 ns | 0.5356 |      - |  14.83 KB |
