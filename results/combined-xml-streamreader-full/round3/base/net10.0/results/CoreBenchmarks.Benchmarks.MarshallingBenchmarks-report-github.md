```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.55 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,645.5 ns | 877.78 ns | 522.35 ns | 0.8523 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,240.4 ns | 517.51 ns | 307.96 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,529.0 ns | 103.37 ns |  61.52 ns | 0.5760 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,954.3 ns | 127.22 ns |  84.15 ns | 0.4200 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    284.9 ns |   3.57 ns |   2.12 ns | 0.1261 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  3,079.1 ns | 918.23 ns | 607.35 ns | 0.5371 |      - |  14.83 KB |
