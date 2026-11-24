```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 72,722.3 ns | 594.83 ns | 353.97 ns | 0.8844 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 81,391.0 ns | 570.41 ns | 377.29 ns | 1.3021 |      - |  36.63 KB |
| Xml_DateTimes             | 23,882.6 ns | 105.93 ns |  55.40 ns | 0.5814 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,754.6 ns | 170.66 ns | 101.56 ns | 0.4223 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    274.1 ns |   0.45 ns |   0.27 ns | 0.1257 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,500.0 ns |  25.04 ns |  14.90 ns | 0.5284 |      - |  14.83 KB |
