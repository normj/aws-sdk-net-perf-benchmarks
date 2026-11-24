```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 2.02 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Gen1   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|-------:|----------:|
| Xml_ListObjectsLike       | 70,354.88 ns | 397.298 ns | 262.788 ns | 0.8408 |      - |   31175 B |
| Xml_ListObjectsStructures | 79,610.02 ns | 124.109 ns |  64.912 ns | 1.2690 |      - |   37520 B |
| Xml_DateTimes             | 23,404.89 ns | 171.867 ns | 102.275 ns | 0.5605 |      - |   18008 B |
| Xml_WriteRequestBody      | 20,837.07 ns | 116.795 ns |  77.252 ns | 0.4161 |      - |   13880 B |
| Xml_HeaderOnlyResponse    |     89.05 ns |   0.360 ns |   0.238 ns | 0.0103 |      - |     296 B |
| Xml_SmallResponse         |  2,514.22 ns |   2.587 ns |   1.353 ns | 0.5387 | 0.0200 |   15222 B |
