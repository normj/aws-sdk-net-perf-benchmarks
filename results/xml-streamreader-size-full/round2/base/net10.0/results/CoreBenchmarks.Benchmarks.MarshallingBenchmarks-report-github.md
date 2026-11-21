```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.37 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,466.8 ns | 757.55 ns | 450.81 ns | 0.8523 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 79,977.3 ns | 552.79 ns | 365.63 ns | 1.3089 |      - |  36.63 KB |
| Xml_DateTimes             | 24,247.8 ns | 163.49 ns | 108.14 ns | 0.5682 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 21,097.5 ns | 340.44 ns | 225.18 ns | 0.4269 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    280.8 ns |   5.64 ns |   3.73 ns | 0.1253 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,522.9 ns |  17.25 ns |  10.26 ns | 0.5370 |      - |  14.83 KB |
