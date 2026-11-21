```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.31 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,501.6 ns | 391.11 ns | 232.74 ns | 0.8562 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,345.5 ns |  83.00 ns |  43.41 ns | 1.2887 |      - |  36.63 KB |
| Xml_DateTimes             | 23,807.0 ns | 158.59 ns | 104.89 ns | 0.5665 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,773.3 ns |  80.67 ns |  48.00 ns | 0.4145 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    277.9 ns |   3.52 ns |   2.32 ns | 0.1257 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,507.9 ns |   7.12 ns |   4.24 ns | 0.5329 |      - |  14.83 KB |
