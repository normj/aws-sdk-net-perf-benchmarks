```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.62 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,867.2 ns | 1,656.10 ns |   590.58 ns | 0.8562 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 82,438.1 ns | 5,323.55 ns | 1,898.43 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,798.7 ns |   249.96 ns |    89.14 ns | 0.5716 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,902.9 ns |   137.73 ns |    49.12 ns | 0.4161 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    274.7 ns |     2.32 ns |     0.60 ns | 0.1262 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,517.2 ns |    22.69 ns |     8.09 ns | 0.5343 |      - |  14.83 KB |
