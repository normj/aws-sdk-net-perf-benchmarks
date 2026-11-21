```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,468.7 ns | 402.88 ns | 239.75 ns | 0.8371 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,447.3 ns | 448.53 ns | 266.91 ns | 1.2376 |      - |   36.6 KB |
| Xml_DateTimes             | 22,599.3 ns |  67.86 ns |  40.38 ns | 0.6322 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,566.9 ns | 111.72 ns |  73.90 ns | 0.4693 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    265.3 ns |   1.09 ns |   0.72 ns | 0.1262 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,396.2 ns |  12.87 ns |   7.66 ns | 0.5351 |      - |  14.82 KB |
