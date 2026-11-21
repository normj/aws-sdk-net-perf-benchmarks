```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.43 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,520.1 ns | 550.67 ns | 327.70 ns | 0.8601 |      - |  30.18 KB |
| Xml_ListObjectsStructures | 79,568.5 ns | 439.38 ns | 261.47 ns | 1.2953 |      - |  36.41 KB |
| Xml_DateTimes             | 23,969.7 ns | 160.23 ns | 105.98 ns | 0.5725 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,895.9 ns |  46.91 ns |  27.91 ns | 0.4189 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    286.0 ns |   4.58 ns |   3.03 ns | 0.1258 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,456.0 ns |   8.06 ns |   4.22 ns | 0.5209 | 0.0098 |   14.6 KB |
