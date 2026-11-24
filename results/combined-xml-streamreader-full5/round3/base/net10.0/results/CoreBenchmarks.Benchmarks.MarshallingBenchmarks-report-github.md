```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,586.1 ns |   574.54 ns | 380.02 ns | 0.8601 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,274.1 ns | 1,090.70 ns | 721.43 ns | 1.2821 |      - |  36.63 KB |
| Xml_DateTimes             | 23,882.6 ns |   304.48 ns | 201.39 ns | 0.5656 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,953.3 ns |   227.69 ns | 135.49 ns | 0.4263 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    301.9 ns |    25.72 ns |  17.01 ns | 0.1262 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,546.0 ns |    21.50 ns |  11.24 ns | 0.5332 |      - |  14.83 KB |
