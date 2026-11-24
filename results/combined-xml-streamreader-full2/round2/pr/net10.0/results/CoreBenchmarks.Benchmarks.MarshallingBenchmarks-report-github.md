```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.52 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error     | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |------------:|----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 78,747.5 ns | 979.91 ns | 648.15 ns | 0.9375 |      - |   31133 B |
| Xml_ListObjectsStructures | 87,503.1 ns | 171.49 ns | 102.05 ns | 1.0593 |      - |   37520 B |
| Xml_DateTimes             | 24,724.2 ns | 224.05 ns | 133.33 ns | 0.5924 |      - |   18011 B |
| Xml_WriteRequestBody      | 20,825.5 ns |  65.51 ns |  43.33 ns | 0.4161 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |    104.6 ns |   0.54 ns |   0.36 ns | 0.0105 |      - |     296 B |
| Xml_SmallResponse         |  2,612.7 ns |  18.64 ns |  12.33 ns | 0.4562 | 0.0104 |   12893 B |
