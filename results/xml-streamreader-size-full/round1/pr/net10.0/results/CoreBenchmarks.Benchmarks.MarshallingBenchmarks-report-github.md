```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 1.95 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 72,198.0 ns | 333.18 ns | 220.38 ns | 0.8601 |      - |   31134 B |
| Xml_ListObjectsStructures | 80,347.2 ns | 518.75 ns | 343.12 ns | 1.2887 |      - |   37512 B |
| Xml_DateTimes             | 23,848.5 ns | 355.31 ns | 235.01 ns | 0.5673 |      - |   17968 B |
| Xml_WriteRequestBody      | 20,856.4 ns | 101.09 ns |  66.87 ns | 0.4167 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    160.6 ns |   0.83 ns |   0.49 ns | 0.0310 |      - |     880 B |
| Xml_SmallResponse         |  2,455.9 ns |   9.63 ns |   6.37 ns | 0.4511 | 0.0196 |   12939 B |
