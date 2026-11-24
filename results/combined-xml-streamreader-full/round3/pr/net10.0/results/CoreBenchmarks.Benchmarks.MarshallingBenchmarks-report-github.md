```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 3.29 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 77,214.5 ns | 496.32 ns | 295.35 ns | 0.9282 |      - |   31133 B |
| Xml_ListObjectsStructures | 86,294.7 ns | 231.42 ns | 137.71 ns | 1.1364 |      - |   37520 B |
| Xml_DateTimes             | 24,821.5 ns | 212.87 ns | 140.80 ns | 0.5924 |      - |   18011 B |
| Xml_WriteRequestBody      | 20,946.4 ns | 159.71 ns |  95.04 ns | 0.4189 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    109.5 ns |   1.71 ns |   1.13 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,618.8 ns |  13.75 ns |   7.19 ns | 0.4503 | 0.0105 |   12893 B |
