```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.42 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,420.0 ns | 245.52 ns | 146.10 ns | 0.8562 |      - |   30.4 KB |
| Xml_ListObjectsStructures | 80,025.6 ns | 378.33 ns | 250.24 ns | 1.2690 |      - |  36.63 KB |
| Xml_DateTimes             | 23,560.6 ns | 136.71 ns |  81.35 ns | 0.5631 |      - |  17.55 KB |
| Xml_WriteRequestBody      | 20,813.5 ns | 128.00 ns |  84.66 ns | 0.4150 |      - |  13.55 KB |
| Xml_HeaderOnlyResponse    |    286.8 ns |   1.41 ns |   0.84 ns | 0.1259 | 0.0011 |   3.48 KB |
| Xml_SmallResponse         |  2,519.7 ns |  20.52 ns |  10.73 ns | 0.5376 |      - |  14.83 KB |
