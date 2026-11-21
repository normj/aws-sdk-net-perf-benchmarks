```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.89 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,269.4 ns | 269.22 ns | 178.07 ns | 0.8371 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,449.3 ns | 576.99 ns | 343.36 ns | 1.2376 |      - |   36.6 KB |
| Xml_DateTimes             | 22,710.0 ns | 149.03 ns |  88.69 ns | 0.5474 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,767.6 ns | 144.55 ns |  86.02 ns | 0.4729 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    264.8 ns |   1.11 ns |   0.66 ns | 0.1261 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,446.3 ns |  22.24 ns |  13.24 ns | 0.5322 |      - |  14.82 KB |
