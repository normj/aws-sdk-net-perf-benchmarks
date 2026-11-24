```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.84 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 80,285.0 ns |   171.95 ns |    89.93 ns | 0.9665 |      - |   31133 B |
| Xml_ListObjectsStructures | 89,788.3 ns |   110.96 ns |    58.03 ns | 1.0776 |      - |   37520 B |
| Xml_DateTimes             | 27,114.7 ns |    30.32 ns |    15.86 ns | 0.5407 |      - |   18011 B |
| Xml_WriteRequestBody      | 22,682.3 ns | 3,284.18 ns | 1,954.36 ns | 0.4293 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    102.0 ns |     0.59 ns |     0.31 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,593.9 ns |    32.05 ns |    16.76 ns | 0.4537 | 0.0106 |   12893 B |
