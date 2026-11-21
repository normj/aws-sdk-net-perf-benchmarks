```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261118
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.76 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 73,129.6 ns | 342.75 ns | 226.71 ns | 0.8762 |      - |  30.18 KB |
| Xml_ListObjectsStructures | 79,991.1 ns | 512.59 ns | 339.04 ns | 1.3021 |      - |  36.41 KB |
| Xml_DateTimes             | 23,886.1 ns | 133.83 ns |  79.64 ns | 0.5716 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,738.5 ns |  31.05 ns |  18.48 ns | 0.4150 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    286.1 ns |   1.83 ns |   1.09 ns | 0.1257 | 0.0012 |   3.48 KB |
| Xml_SmallResponse         |  2,438.0 ns |  10.62 ns |   6.32 ns | 0.5262 | 0.0097 |   14.6 KB |
