```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.93 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 73,356.7 ns |   180.96 ns | 107.69 ns | 0.9470 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 83,133.7 ns |   349.02 ns | 230.86 ns | 0.9973 |      - |   36.6 KB |
| Xml_DateTimes             | 25,151.4 ns |   179.50 ns | 106.82 ns | 0.6039 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 21,374.2 ns |   113.53 ns |  67.56 ns | 0.4269 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    368.8 ns |    16.25 ns |  10.75 ns | 0.1255 | 0.0014 |   3.48 KB |
| Xml_SmallResponse         |  3,322.9 ns | 1,313.76 ns | 868.97 ns | 0.5323 |      - |  14.82 KB |
