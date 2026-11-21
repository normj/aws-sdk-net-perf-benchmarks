```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,721.8 ns | 505.50 ns | 300.81 ns | 0.8523 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 79,595.1 ns | 226.59 ns | 149.87 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,505.7 ns | 165.59 ns |  98.54 ns | 0.5673 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,798.7 ns |  94.60 ns |  49.48 ns | 0.4167 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    285.3 ns |   4.10 ns |   2.44 ns | 0.1258 | 0.0012 |   3.48 KB |
| Xml_SmallResponse         |  2,490.5 ns |   5.58 ns |   3.32 ns | 0.5345 |      - |  14.83 KB |
