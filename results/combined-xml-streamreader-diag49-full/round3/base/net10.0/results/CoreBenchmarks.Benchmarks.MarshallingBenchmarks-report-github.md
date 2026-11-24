```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.66 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,676.4 ns | 389.34 ns | 231.69 ns | 0.8562 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,189.7 ns | 371.46 ns | 245.70 ns | 1.2755 |      - |  36.63 KB |
| Xml_DateTimes             | 23,560.7 ns | 206.39 ns | 122.82 ns | 0.5648 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,810.2 ns |  37.89 ns |  22.55 ns | 0.4156 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    277.5 ns |   0.83 ns |   0.50 ns | 0.1258 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,477.5 ns |   4.80 ns |   2.86 ns | 0.5346 |      - |  14.83 KB |
