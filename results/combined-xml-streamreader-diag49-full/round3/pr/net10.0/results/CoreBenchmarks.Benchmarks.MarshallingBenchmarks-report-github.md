```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.63 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,997.64 ns | 874.234 ns | 457.241 ns | 0.8446 |      - |   31175 B |
| Xml_ListObjectsStructures | 80,174.40 ns | 400.639 ns | 264.998 ns | 1.2755 |      - |   37520 B |
| Xml_DateTimes             | 23,520.65 ns | 210.426 ns | 139.184 ns | 0.5639 |      - |   18008 B |
| Xml_WriteRequestBody      | 20,963.54 ns |  23.160 ns |  12.113 ns | 0.4189 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     87.32 ns |   0.419 ns |   0.250 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,532.45 ns |   6.264 ns |   3.276 ns | 0.5377 | 0.0203 |   15222 B |
