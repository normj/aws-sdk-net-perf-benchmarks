```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,794.4 ns |   568.89 ns | 202.87 ns | 0.8446 |      - |  30.18 KB |
| Xml_ListObjectsStructures | 79,141.4 ns | 1,041.56 ns | 371.43 ns | 1.2563 |      - |  36.41 KB |
| Xml_DateTimes             | 23,854.4 ns |   228.83 ns |  59.43 ns | 0.5690 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,950.1 ns |   244.26 ns |  63.43 ns | 0.4223 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    287.6 ns |    11.88 ns |   4.24 ns | 0.1255 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,465.6 ns |    31.11 ns |  11.09 ns | 0.5210 | 0.0098 |   14.6 KB |
