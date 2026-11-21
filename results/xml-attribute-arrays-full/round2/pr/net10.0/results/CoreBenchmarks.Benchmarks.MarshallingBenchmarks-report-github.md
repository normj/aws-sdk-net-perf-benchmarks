```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.81 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,963.8 ns | 698.06 ns | 461.72 ns | 0.8446 |      - |  30.18 KB |
| Xml_ListObjectsStructures | 79,055.5 ns | 421.38 ns | 250.76 ns | 1.2563 |      - |  36.41 KB |
| Xml_DateTimes             | 23,873.9 ns | 109.24 ns |  65.00 ns | 0.5716 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,723.3 ns | 136.10 ns |  71.18 ns | 0.4128 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    270.1 ns |   2.12 ns |   1.40 ns | 0.1263 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,438.3 ns |   9.77 ns |   5.11 ns | 0.5285 | 0.0098 |   14.6 KB |
