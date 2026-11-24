```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,320.3 ns | 1,171.21 ns | 774.68 ns | 0.8446 |      - |   31099 B |
| Xml_ListObjectsStructures | 81,000.9 ns |   261.41 ns | 172.90 ns | 1.2887 |      - |   37519 B |
| Xml_DateTimes             | 23,348.9 ns |   135.60 ns |  70.92 ns | 0.5614 |      - |   17980 B |
| Xml_WriteRequestBody      | 20,868.0 ns |   188.90 ns | 124.95 ns | 0.4145 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    109.7 ns |     0.18 ns |   0.09 ns | 0.0101 |      - |     296 B |
| Xml_SmallResponse         |  2,453.4 ns |     5.17 ns |   2.70 ns | 0.4557 | 0.0194 |   12960 B |
