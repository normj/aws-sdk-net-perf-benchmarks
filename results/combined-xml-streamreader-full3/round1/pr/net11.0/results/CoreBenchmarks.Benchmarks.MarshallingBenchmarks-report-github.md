```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.4 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 69,523.64 ns | 210.239 ns | 125.110 ns | 0.8371 |      - |   31141 B |
| Xml_ListObjectsStructures | 77,796.59 ns | 273.826 ns | 162.950 ns | 1.2438 |      - |   37483 B |
| Xml_DateTimes             | 22,910.92 ns |  71.882 ns |  37.596 ns | 0.5490 |      - |   18020 B |
| Xml_WriteRequestBody      | 19,713.56 ns | 167.958 ns |  99.949 ns | 0.4717 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     98.75 ns |   0.310 ns |   0.205 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,381.25 ns |  44.929 ns |  29.718 ns | 0.4527 | 0.0189 |   12960 B |
