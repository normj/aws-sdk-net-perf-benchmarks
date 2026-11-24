```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.3 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,272.95 ns | 437.309 ns | 260.236 ns | 0.8523 |      - |   31099 B |
| Xml_ListObjectsStructures | 80,199.16 ns | 305.330 ns | 181.697 ns | 1.2755 |      - |   37519 B |
| Xml_DateTimes             | 23,412.05 ns | 101.847 ns |  53.268 ns | 0.5605 |      - |   17980 B |
| Xml_WriteRequestBody      | 20,702.46 ns |  31.056 ns |  16.243 ns | 0.4145 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     89.82 ns |   0.374 ns |   0.223 ns | 0.0104 |      - |     296 B |
| Xml_SmallResponse         |  2,452.40 ns |  62.925 ns |  41.621 ns | 0.4547 | 0.0193 |   12960 B |
