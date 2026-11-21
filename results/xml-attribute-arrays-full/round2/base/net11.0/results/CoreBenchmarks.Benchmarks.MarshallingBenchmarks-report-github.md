```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.77 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,975.2 ns | 907.44 ns | 540.00 ns | 1.0965 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 76,537.6 ns | 169.53 ns | 100.88 ns | 1.2315 |      - |   36.6 KB |
| Xml_DateTimes             | 22,757.3 ns | 114.26 ns |  75.58 ns | 0.6350 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,569.5 ns |  60.94 ns |  31.87 ns | 0.4699 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    264.8 ns |   0.70 ns |   0.42 ns | 0.1263 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,476.4 ns |  13.19 ns |   8.72 ns | 0.5340 |      - |  14.82 KB |
