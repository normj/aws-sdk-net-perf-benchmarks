```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,779.5 ns | 892.41 ns | 466.75 ns | 0.8562 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 79,735.4 ns | 178.74 ns |  93.49 ns | 1.2953 |      - |  36.63 KB |
| Xml_DateTimes             | 23,520.4 ns |  92.30 ns |  48.27 ns | 0.5708 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,660.2 ns |  44.77 ns |  26.64 ns | 0.4134 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    285.2 ns |   6.71 ns |   3.99 ns | 0.1264 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,512.9 ns |   8.87 ns |   5.28 ns | 0.5310 |      - |  14.83 KB |
