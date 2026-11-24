```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.49 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,589.6 ns | 568.39 ns | 338.24 ns | 0.8562 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,049.1 ns | 362.22 ns | 215.55 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,467.8 ns |  90.42 ns |  47.29 ns | 0.5622 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,829.7 ns |  88.89 ns |  52.90 ns | 0.4172 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    300.2 ns |  16.63 ns |  11.00 ns | 0.1255 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,529.8 ns |  11.57 ns |   6.05 ns | 0.5328 |      - |  14.83 KB |
