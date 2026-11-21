```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.14 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,304.1 ns | 333.77 ns | 198.62 ns | 0.8296 |      - |   31123 B |
| Xml_ListObjectsStructures | 76,521.6 ns | 139.66 ns |  73.05 ns | 1.2438 |      - |   37476 B |
| Xml_DateTimes             | 22,877.6 ns | 210.74 ns | 139.39 ns | 0.5482 |      - |   18002 B |
| Xml_WriteRequestBody      | 19,634.8 ns | 450.21 ns | 267.91 ns | 0.4670 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    164.0 ns |   0.47 ns |   0.25 ns | 0.0311 |      - |     880 B |
| Xml_SmallResponse         |  2,401.6 ns |   9.24 ns |   4.83 ns | 0.4526 | 0.0193 |   12876 B |
