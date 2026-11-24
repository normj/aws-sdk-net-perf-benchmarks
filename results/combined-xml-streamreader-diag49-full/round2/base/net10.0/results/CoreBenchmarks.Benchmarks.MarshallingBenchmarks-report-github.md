```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,725.9 ns | 597.96 ns | 355.84 ns | 0.8562 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,115.8 ns | 477.13 ns | 249.55 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,488.1 ns |  92.93 ns |  61.47 ns | 0.5622 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,744.3 ns |  46.14 ns |  27.46 ns | 0.4150 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    270.9 ns |   0.89 ns |   0.53 ns | 0.1260 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,489.5 ns |   8.20 ns |   4.88 ns | 0.5362 |      - |  14.83 KB |
