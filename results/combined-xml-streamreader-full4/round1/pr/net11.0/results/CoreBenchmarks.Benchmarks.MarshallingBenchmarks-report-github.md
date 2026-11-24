```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.74 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
  InProcess : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 11.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike       | 68,944.09 ns | 256.621 ns | 152.711 ns | 1.1013 |   31149 B |
| Xml_ListObjectsStructures | 78,541.72 ns | 708.366 ns | 468.540 ns | 1.2500 |   37492 B |
| Xml_DateTimes             | 22,682.49 ns |  56.873 ns |  29.745 ns | 0.6341 |   18028 B |
| Xml_WriteRequestBody      | 19,714.56 ns |  62.887 ns |  37.423 ns | 0.4729 |   13880 B |
| Xml_HeaderOnlyResponse    |     88.81 ns |   0.614 ns |   0.406 ns | 0.0106 |     304 B |
| Xml_SmallResponse         |  2,305.87 ns |  17.153 ns |  10.207 ns | 0.4514 |   12968 B |
