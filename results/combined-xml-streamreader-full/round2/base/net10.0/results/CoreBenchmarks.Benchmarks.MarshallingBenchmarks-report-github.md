```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.19 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 73,264.3 ns |   807.63 ns |   480.60 ns | 0.8601 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 81,762.8 ns |   829.53 ns |   433.86 ns | 1.3228 |      - |  36.63 KB |
| Xml_DateTimes             | 23,735.9 ns |   288.62 ns |   190.91 ns | 0.5778 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 21,586.0 ns | 2,263.18 ns | 1,346.78 ns | 0.4200 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    306.7 ns |    47.83 ns |    31.64 ns | 0.1263 | 0.0013 |   3.48 KB |
| Xml_SmallResponse         |  2,887.5 ns |   782.40 ns |   517.51 ns | 0.5320 |      - |  14.83 KB |
