```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.53 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,678.1 ns | 485.98 ns | 289.20 ns | 0.8601 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,364.6 ns | 340.58 ns | 202.67 ns | 1.2887 |      - |  36.63 KB |
| Xml_DateTimes             | 23,581.1 ns | 127.12 ns |  66.49 ns | 0.5631 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,772.1 ns |  86.97 ns |  51.75 ns | 0.4139 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    283.1 ns |   1.32 ns |   0.78 ns | 0.1263 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,493.3 ns |  16.86 ns |  10.03 ns | 0.5370 |      - |  14.83 KB |
