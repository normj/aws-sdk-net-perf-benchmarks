```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,962.3 ns | 492.20 ns | 325.56 ns | 0.8641 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,115.6 ns | 417.58 ns | 276.20 ns | 1.3089 |      - |  36.63 KB |
| Xml_DateTimes             | 24,107.8 ns | 302.85 ns | 180.22 ns | 0.5796 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,808.6 ns |  71.21 ns |  47.10 ns | 0.4150 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    283.9 ns |   1.18 ns |   0.78 ns | 0.1256 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,539.6 ns |   7.89 ns |   5.22 ns | 0.5328 |      - |  14.83 KB |
