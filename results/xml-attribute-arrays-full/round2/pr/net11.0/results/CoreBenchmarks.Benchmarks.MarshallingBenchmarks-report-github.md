```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,230.6 ns | 351.98 ns | 209.46 ns | 0.8333 |      - |  30.17 KB |
| Xml_ListObjectsStructures | 77,582.6 ns | 695.76 ns | 414.04 ns | 1.2315 |      - |  36.37 KB |
| Xml_DateTimes             | 23,261.7 ns | 385.08 ns | 254.71 ns | 0.5531 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,724.6 ns |  29.27 ns |  17.42 ns | 0.4753 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    272.3 ns |   6.10 ns |   4.03 ns | 0.1263 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,363.1 ns |  19.79 ns |  11.78 ns | 0.5251 | 0.0094 |   14.6 KB |
