```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.12 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 72,594.7 ns |   512.65 ns | 305.07 ns | 0.8681 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 82,171.8 ns | 1,420.98 ns | 845.60 ns | 1.2887 |      - |  36.63 KB |
| Xml_DateTimes             | 23,682.9 ns |   304.65 ns | 201.51 ns | 0.5725 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,776.5 ns |    76.47 ns |  50.58 ns | 0.4167 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    277.1 ns |     8.33 ns |   5.51 ns | 0.1261 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,532.3 ns |     9.15 ns |   4.79 ns | 0.5298 |      - |  14.83 KB |
