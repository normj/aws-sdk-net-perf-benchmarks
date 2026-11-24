```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.65 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,559.6 ns | 1,154.13 ns | 686.80 ns | 0.8333 |      - |  30.39 KB |
| Xml_ListObjectsStructures | 77,867.1 ns |   652.48 ns | 388.28 ns | 1.2953 |      - |   36.6 KB |
| Xml_DateTimes             | 22,609.2 ns |    96.39 ns |  50.41 ns | 0.6359 |      - |  17.58 KB |
| Xml_WriteRequestBody      | 19,933.5 ns |   224.46 ns | 148.47 ns | 0.4777 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    270.4 ns |     0.56 ns |   0.33 ns | 0.1254 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,438.5 ns |   111.81 ns |  66.54 ns | 0.5329 |      - |  14.82 KB |
