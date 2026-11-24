```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.47 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,161.6 ns | 330.20 ns | 196.49 ns | 1.0870 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 76,797.2 ns | 619.03 ns | 368.37 ns | 1.2626 |      - |   36.6 KB |
| Xml_DateTimes             | 22,910.7 ns | 127.12 ns |  84.08 ns | 0.5556 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,789.9 ns |  62.09 ns |  36.95 ns | 0.4747 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    269.6 ns |   0.91 ns |   0.54 ns | 0.1261 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,483.9 ns |   9.48 ns |   5.64 ns | 0.5346 |      - |  14.82 KB |
