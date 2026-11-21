```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.31 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,884.9 ns |   233.38 ns | 122.06 ns | 0.8562 |      - |   31134 B |
| Xml_ListObjectsStructures | 81,923.3 ns | 1,383.04 ns | 723.36 ns | 1.2953 |      - |   37512 B |
| Xml_DateTimes             | 23,790.4 ns |   109.21 ns |  72.24 ns | 0.5752 |      - |   17968 B |
| Xml_WriteRequestBody      | 20,779.7 ns |    98.29 ns |  65.01 ns | 0.4139 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    169.6 ns |     1.19 ns |   0.71 ns | 0.0310 |      - |     880 B |
| Xml_SmallResponse         |  2,439.5 ns |     3.10 ns |   1.62 ns | 0.4575 | 0.0199 |   12939 B |
