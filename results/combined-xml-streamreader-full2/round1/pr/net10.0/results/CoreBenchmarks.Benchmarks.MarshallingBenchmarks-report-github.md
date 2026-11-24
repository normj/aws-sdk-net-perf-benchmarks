```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.40GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 6.54 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev    | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 77,811.42 ns | 116.638 ns | 61.004 ns | 0.9282 |      - |   31133 B |
| Xml_ListObjectsStructures | 86,725.99 ns | 156.292 ns | 81.744 ns | 1.0714 |      - |   37520 B |
| Xml_DateTimes             | 24,644.90 ns | 117.410 ns | 69.869 ns | 0.5934 |      - |   18011 B |
| Xml_WriteRequestBody      | 20,674.20 ns |  86.480 ns | 51.463 ns | 0.4334 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     99.68 ns |   0.523 ns |  0.273 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,580.42 ns |   5.794 ns |  3.030 ns | 0.4527 | 0.0103 |   12893 B |
