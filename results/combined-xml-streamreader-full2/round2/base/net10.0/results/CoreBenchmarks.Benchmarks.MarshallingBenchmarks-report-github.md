```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.51 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,790.9 ns |   335.15 ns |   221.68 ns | 0.8601 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 81,931.2 ns | 3,567.83 ns | 2,359.90 ns | 1.2821 |      - |  36.63 KB |
| Xml_DateTimes             | 23,764.4 ns |   241.66 ns |   159.85 ns | 0.5716 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,781.9 ns |   105.01 ns |    69.46 ns | 0.4150 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    285.6 ns |     0.92 ns |     0.61 ns | 0.1257 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,523.1 ns |    14.44 ns |     8.59 ns | 0.5364 |      - |  14.83 KB |
