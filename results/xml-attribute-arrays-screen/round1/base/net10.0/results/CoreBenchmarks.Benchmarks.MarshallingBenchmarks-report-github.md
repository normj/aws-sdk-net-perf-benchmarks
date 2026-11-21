```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 8.06 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=6  IterationTime=250ms  WarmupCount=2  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 73,815.5 ns | 2,877.52 ns | 1,026.15 ns | 0.8681 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 81,050.6 ns | 3,582.23 ns | 1,277.46 ns | 1.3089 |      - |  36.63 KB |
| Xml_DateTimes             | 23,757.8 ns |   317.09 ns |   113.08 ns | 0.5673 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,865.9 ns |   149.14 ns |    38.73 ns | 0.4161 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    275.3 ns |     1.80 ns |     0.47 ns | 0.1255 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,514.7 ns |    21.94 ns |     7.83 ns | 0.5320 |      - |  14.83 KB |
