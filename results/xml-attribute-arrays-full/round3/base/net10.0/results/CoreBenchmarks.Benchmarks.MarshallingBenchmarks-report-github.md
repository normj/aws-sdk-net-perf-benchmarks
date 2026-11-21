```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,390.3 ns | 632.45 ns | 418.33 ns | 0.8523 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 79,412.6 ns | 151.84 ns |  79.42 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,593.3 ns | 143.94 ns |  95.20 ns | 0.5631 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,674.1 ns |  96.96 ns |  57.70 ns | 0.4134 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    277.8 ns |   1.59 ns |   0.83 ns | 0.1262 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,462.1 ns |  11.70 ns |   6.96 ns | 0.5313 |      - |  14.83 KB |
