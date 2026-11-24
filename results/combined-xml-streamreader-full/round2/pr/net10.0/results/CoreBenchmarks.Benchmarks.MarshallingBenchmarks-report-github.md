```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.67 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|------------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 79,601.9 ns |   186.93 ns | 111.24 ns | 0.9422 |      - |   31133 B |
| Xml_ListObjectsStructures | 89,597.5 ns | 1,262.82 ns | 751.49 ns | 1.0901 |      - |   37520 B |
| Xml_DateTimes             | 25,131.0 ns |   530.39 ns | 350.82 ns | 0.6039 |      - |   18011 B |
| Xml_WriteRequestBody      | 21,122.5 ns |   165.79 ns | 109.66 ns | 0.4178 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    113.9 ns |    24.94 ns |  16.50 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,710.2 ns |    26.54 ns |  17.56 ns | 0.4535 | 0.0108 |   12893 B |
