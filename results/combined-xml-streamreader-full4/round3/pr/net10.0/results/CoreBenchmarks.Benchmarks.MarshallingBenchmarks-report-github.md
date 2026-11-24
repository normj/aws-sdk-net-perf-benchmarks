```

BenchmarkDotNet v0.16.0-preview.2, Linux Amazon Linux 2023.12.20261120
Intel Xeon Platinum 8375C CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
Memory: 30.81 GB Total, 5.82 GB Available
.NET SDK 11.0.100
  [Host]    : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4
  InProcess : .NET 10.0.15 (10.0.15, 10.0.1526.53008), X64 RyuJIT x86-64-v4

Job=InProcess  Runtime=.NET 10.0  Toolchain=InProcessEmitToolchain  
IterationCount=10  IterationTime=250ms  WarmupCount=3  

```
| Method                    | Mean         | Error      | StdDev     | Gen0   | Allocated |
|-------------------------- |-------------:|-----------:|-----------:|-------:|----------:|
| Xml_ListObjectsLike       | 71,215.06 ns | 870.615 ns | 575.858 ns | 0.8484 |   31108 B |
| Xml_ListObjectsStructures | 81,114.13 ns | 586.593 ns | 387.995 ns | 1.2953 |   37527 B |
| Xml_DateTimes             | 23,463.58 ns | 131.764 ns |  78.411 ns | 0.5622 |   17987 B |
| Xml_WriteRequestBody      | 20,879.70 ns |  40.490 ns |  21.177 ns | 0.4200 |   13880 B |
| Xml_HeaderOnlyResponse    |     88.29 ns |   0.280 ns |   0.146 ns | 0.0106 |     304 B |
| Xml_SmallResponse         |  2,462.47 ns |  17.107 ns |   8.947 ns | 0.4520 |   12968 B |
