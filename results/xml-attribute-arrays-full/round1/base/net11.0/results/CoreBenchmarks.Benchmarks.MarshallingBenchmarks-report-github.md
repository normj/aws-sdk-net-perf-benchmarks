```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.7 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,397.6 ns | 338.69 ns | 201.55 ns | 0.8371 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,807.7 ns | 426.09 ns | 253.56 ns | 1.2438 |      - |   36.6 KB |
| Xml_DateTimes             | 22,770.8 ns | 149.72 ns |  99.03 ns | 0.5482 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 20,141.8 ns | 377.56 ns | 249.73 ns | 0.4705 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    308.1 ns |  21.86 ns |  13.01 ns | 0.1253 | 0.0013 |   3.48 KB |
| Xml_SmallResponse         |  2,779.3 ns | 308.45 ns | 204.02 ns | 0.5327 |      - |  14.82 KB |
