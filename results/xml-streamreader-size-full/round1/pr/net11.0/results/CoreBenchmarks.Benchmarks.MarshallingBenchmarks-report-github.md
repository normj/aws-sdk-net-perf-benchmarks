```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.99 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,961.9 ns | 1,481.68 ns | 980.04 ns | 1.0870 |      - |   31123 B |
| Xml_ListObjectsStructures | 76,215.1 ns |   252.67 ns | 132.15 ns | 1.2136 |      - |   37476 B |
| Xml_DateTimes             | 22,603.1 ns |   142.11 ns |  94.00 ns | 0.6341 |      - |   18002 B |
| Xml_WriteRequestBody      | 20,171.8 ns |    51.17 ns |  30.45 ns | 0.4858 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    164.5 ns |     2.12 ns |   1.40 ns | 0.0309 |      - |     880 B |
| Xml_SmallResponse         |  2,359.6 ns |    24.46 ns |  14.56 ns | 0.4481 | 0.0191 |   12876 B |
