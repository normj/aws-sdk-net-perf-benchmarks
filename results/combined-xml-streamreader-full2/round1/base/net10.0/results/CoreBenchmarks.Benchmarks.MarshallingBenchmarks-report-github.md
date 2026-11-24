```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz (Max: 3.41GHz), 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 4.58 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean        | Error       | StdDev      | Gen0   | Allocated |
|-------------------------- |------------:|------------:|------------:|-------:|----------:|
| Xml_ListObjectsLike       | 77,407.7 ns | 4,915.49 ns | 3,251.29 ns | 0.9014 |   30.4 KB |
| Xml_ListObjectsStructures | 84,231.3 ns |   690.39 ns |   410.84 ns | 1.0027 |  36.63 KB |
| Xml_DateTimes             | 25,645.5 ns |   120.65 ns |    71.79 ns | 0.6098 |  17.55 KB |
| Xml_WriteRequestBody      | 22,416.3 ns |   147.27 ns |    97.41 ns | 0.4496 |  13.55 KB |
| Xml_HeaderOnlyResponse    |    663.7 ns |    47.29 ns |    31.28 ns | 0.1241 |   3.48 KB |
| Xml_SmallResponse         |  4,368.1 ns |   135.43 ns |    89.58 ns | 0.5216 |  14.83 KB |
